using ContosoUniversity.API.DTOs;
using ContosoUniversity.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("echoping")]
        public async Task<IActionResult> EchoPing()
        {
            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(UserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest();

            bool isCredentialValid = (userDTO.Password == "123456");

            if (isCredentialValid)
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Username = "dsantafe",
                    Email = "dsantafe@utap.edu.co"
                };

                var token = GenerateTokenJwt(user);
                return Ok(token);
            }
            else
                return Unauthorized();
        }

        private string GenerateTokenJwt(User user)
        {
            //appsetting JWT
            var secretKey = configuration["JWT:SECRET_KEY"];
            var audienceToken = configuration["JWT:AUDIENCE_TOKEN"];
            var issuerToken = configuration["JWT:ISSUER_TOKEN"];
            var expireTime = configuration["JWT:EXPIRE_MINUTES"];

            //header
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var siginCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(siginCredentials);

            //claims
            var claimsIdentity = new[] {
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(ClaimTypes.Name , user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var payload = new JwtPayload(issuer: issuerToken,
                audience: audienceToken,
                claims: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)));

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}