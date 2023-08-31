using Backend.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Utils
{
    /// <summary>
    /// Utility class for building access tokens.
    /// </summary>
    public class TokenBuilder
    {
        /// <summary>
        /// Generates an access token for a user.
        /// </summary>
        /// <param name="configuration">The application configuration.</param>
        /// <param name="user">The user for whom the access token is generated.</param>
        /// <returns>The generated access token as a string.</returns>
        public static string AccessToken(IConfiguration configuration, User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            var tokenKey = configuration.GetSection("AppSettings:Token").Value!;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
