using AutoMapper;
using Backend.Entities;
using Backend.Exceptions;
using Backend.Models.Auths;
using Backend.Repositories.Users;
using System.Security.Claims;

namespace Backend.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserService(IMapper mapper, IUserRepository userRepository, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
        }

        public async Task<int> AddUser(User newUser)
        {
            var user = _mapper.Map<User>(newUser);
            user.Id = await _userRepository.AddUser(user);
            return user.Id;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteUser(id);
            if (!user)
            {
                throw new UserDeletionFailedException("An error occurred while attempting to delete the user.");
            }
            return user;
        }

        public async Task<User> GetUser(User user)
        {
            return await _userRepository.GetUser(user);
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if(user is null)
            {
                throw new UserNotFoundException("User not found.");
            }
            return _mapper.Map<User>(user);
        }

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

        public async Task<User> UpdateUser(int id, UserRegisterDto updateUser)
        {
            var dbUser = _mapper.Map<User>(updateUser);
            dbUser.Id = id;

            var result = await _userRepository.UpdateUser(dbUser);
            if (!result)
            {
                throw new UserUpdateFailedException("User update failed.");
            }

            return _mapper.Map<User>(dbUser);

        }
    }
}
