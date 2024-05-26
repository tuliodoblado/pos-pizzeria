using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_pospizzeria.Features.Services
{
    public class GenerateToken
    {
        private IConfiguration config;

        public GenerateToken( IConfiguration config)
        {
            this.config = config;
        }

        public string CreateToken(Ousr authentication)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.UserData, authentication.NameUser),
                new Claim(ClaimTypes.SerialNumber, Convert.ToString(authentication.Id)),
                new Claim(ClaimTypes.Role, Convert.ToString(authentication.IdRol)),
                new Claim(ClaimTypes.Name, authentication.Name?? "")

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                                claims: claims,
                                expires: DateTime.Now.AddHours(12),
                                signingCredentials: creds);

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

    }
}
