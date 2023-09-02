using AutoMapper;
using Backend.Entities;
using Backend.Exceptions.Users;
using Backend.Models.Auths;
using Backend.Services.UserAuditService;
using Backend.Services.Users;
using Backend.Utils;

namespace Backend.Services.Auths
{
    /// <summary>
    /// Service for authentication-related operations.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IUserAuditService _userAuditService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="userService">The user service.</param>
        /// <param name="userAuditService">The user audit service.</param>
        public AuthService(IMapper mapper, IConfiguration configuration, IUserService userService, IUserAuditService userAuditService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _userAuditService = userAuditService ?? throw new ArgumentNullException(nameof(userAuditService));
        }

        /// <inheritdoc/>
        public async Task<AuthUserDto> AuthLogin(UserLoginDto request)
        {
            var userModel = _mapper.Map<User>(request);
            var user = await _userService.GetUser(userModel);

            if (user is null)
            {
                throw new UserNotFoundException("User does not exist.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password, user.PasswordSalt);

            if (!user.Password.Equals(passwordHash))
            {
                throw new UserAuthenticationFailedException("Incorrect password.");
            }

            var response = _mapper.Map<AuthUserDto>(user);
            response.Token = TokenBuilder.AccessToken(_configuration, user);

            await _userAuditService.UserAuthenticationAudit(
                user,
                $"User {user.FirstName} {user.LastName} logged in.",
                "Log in"
              );

            return response;
        }

        /// <inheritdoc/>
        public async Task<AuthUserDto> AuthRegister(UserRegisterDto request)
        {
            var user = _mapper.Map<User>(request);
            var userExists = await _userService.GetUser(user);
            if (userExists != null)
            {
                throw new UserAuthenticationFailedException("User already exists.");
            }

            var newUser = _mapper.Map<User>(request);

            string passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();

            newUser.PasswordSalt = passwordSalt;
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(request.Password, passwordSalt);

            newUser.Id = await _userService.AddUser(newUser);

            var response = _mapper.Map<AuthUserDto>(newUser);
            response.Token = TokenBuilder.AccessToken(_configuration, newUser);

            await _userAuditService.UserAuthenticationAudit(
                newUser,
                $"User {user.FirstName} {user.LastName} created an account.",
                "Sign up"
            );

            return response;
        }
    }
}
