using Backend.Models.Auths;

namespace Backend.Services.Auths
{
    /// <summary>
    /// Provides methods for user authentication and registration.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates a user's login request.
        /// </summary>
        /// <param name="request">The user's login information.</param>
        /// <returns>An authenticated user data transfer object if login is successful, otherwise null.</returns>
        Task<AuthUserDto> AuthLogin(UserLoginDto request);

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="request">The user's registration information.</param>
        /// <returns>An authenticated user data transfer object if registration is successful, otherwise null.</returns>
        Task<AuthUserDto> AuthRegister(UserRegisterDto request);
    }
}
