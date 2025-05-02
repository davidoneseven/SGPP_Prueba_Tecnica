using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SGPP_API.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Options;

namespace SGPP_API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthAPIController : ControllerBase
    {
        private readonly JwtProperties _jwtProperties;

        public AuthAPIController(IOptions<JwtProperties> jwtProperties)
        {
            _jwtProperties = jwtProperties.Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]AuthRequest request)
        {
            if (request.Username == "admin" && request.Password == "Abc123$%")
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.UTF8.GetBytes(_jwtProperties.SecretKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, request.Username)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(_jwtProperties.ExpirationMinutes),
                    Issuer = _jwtProperties.Issuer,
                    Audience = _jwtProperties.Audience,
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                    )
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                return Ok(new AuthResponse{ Token = jwtToken });
            }

            return Unauthorized();
        }
    }
}
