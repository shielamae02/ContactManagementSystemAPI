using AutoMapper;
using Backend.Entities;
using Backend.Models.Auths;
using Backend.Services.Users;
using Backend.Utils;

namespace Backend.Services.Auths
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;
        public AuthService(IMapper mapper, IConfiguration configuration, ILogger<AuthService> logger, IUserService userService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AuthUserDto> AuthLogin(UserLoginDto request)
        {
            var userModel = _mapper.Map<User>(request);
            var user = await _userService.GetUser(userModel);

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password, user.PasswordSalt);
            if(!user.Password.Equals(passwordHash))
            {
                throw new Exception("Incorrect password.");
            }

            var response = _mapper.Map<AuthUserDto>(user);
            response.Token = TokenBuilder.AccessToken(_configuration, user);

            return response;
        }

        public async Task<AuthUserDto> AuthRegister(UserRegisterDto request)
        {
            var user = _mapper.Map<User>(request);
            var userExists = await _userService.GetUser(user);
            if (userExists != null)
            {
                throw new Exception("User already exists.");
            }

            var newUser = _mapper.Map<User>(request);

            string passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();

            newUser.PasswordSalt = passwordSalt;
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(request.Password, passwordSalt);

            newUser.Id = await _userService.AddUser(newUser);

            var response = _mapper.Map<AuthUserDto>(newUser);
            response.Token = TokenBuilder.AccessToken(_configuration, newUser);

            return response;
        }
    }
}
