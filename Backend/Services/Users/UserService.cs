using AutoMapper;
using Backend.Entities;
using Backend.Exceptions.Users;
using Backend.Models.Auths;
using Backend.Repositories.Users;
using Backend.Services.UserAuditService;
using System.Security.Claims;

namespace Backend.Services.Users
{
    /// <summary>
    /// Service for user-related operations.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserAuditService _userAuditService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="contextAccessor">The HTTP context accessor.</param>
        /// <param name="userAuditService">The user audit service.</param>
        public UserService(IMapper mapper, IUserRepository userRepository, IHttpContextAccessor contextAccessor, IUserAuditService userAuditService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            _userAuditService = userAuditService ?? throw new ArgumentNullException(nameof(userAuditService));
        }

        /// <inheritdoc/>
        public async Task<int> AddUser(User newUser)
        {
            var user = _mapper.Map<User>(newUser);
            user.Id = await _userRepository.AddUser(user);
            return user.Id;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteUser(id);
            var dbUser = await _userRepository.GetUserById(id);
            if (!user)
            {
                throw new UserDeletionFailedException("An error occurred while attempting to delete the user.");
            }

            await _userAuditService.UserAuthenticationAudit(
               dbUser,
               $"User with ID {id} deleted his/her account.",
               "Delete"
           );


            return user;
        }

        /// <inheritdoc/>
        public async Task<User> GetUser(User user)
        {
            return await _userRepository.GetUser(user);
        }


        /// <inheritdoc/>
        public async Task<User> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
            {
                throw new UserNotFoundException("User not found.");
            }

            return _mapper.Map<User>(user);
        }

        /// <inheritdoc/>
        public async Task<int> GetUserId()
        {
            var result = _contextAccessor.HttpContext!.User.Identity as ClaimsIdentity;
            if (result is null)
            {
                throw new UserNotFoundException("User not found.");
            }
            var userClaims = result.Claims;
            var user = new User
            {
                EmailAddress = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value!,
                Id = Convert.ToInt32(userClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value!)
            };

            return user.Id;
        }

        /// <inheritdoc/>
        public async Task<User> UpdateUser(int id, UpdateUserDto updateUser)
        {
            var user = await GetUserById(id);
            var dbUser = _mapper.Map<User>(updateUser);
            dbUser.Id = id;

            var result = await _userRepository.UpdateUser(dbUser);
            if (!result)
            {
                throw new UserUpdateFailedException("User update failed.");
            }


            await _userAuditService.UserAuthenticationAudit(
                user,
                $"User {user.FirstName} {user.LastName} updated his/her profile.",
                "Update"
            );

            return _mapper.Map<User>(dbUser);
        }
    }
}
