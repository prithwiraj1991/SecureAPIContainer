using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SecureAPIContainer.Auth;

namespace SecureAPIContainer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public AuthController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        [HttpPost("token")]
        public IActionResult GetToken([FromBody] LoginModel login)
        {
            if (IsValidUser(login))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, login.Username)
                }),
                    Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }

        private bool IsValidUser(LoginModel login)
        {
            // Validate the user credentials here (e.g., check against a database)
            return true;
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
