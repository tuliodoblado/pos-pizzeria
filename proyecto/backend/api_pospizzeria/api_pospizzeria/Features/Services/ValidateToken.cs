using api_pospizzeria.Features.FAccess.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace api_pospizzeria.Features.Services
{
    public class ValidateToken
    {
        private IConfiguration config;

        public ValidateToken(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<bool> MValidateToken(ValidateDto token)
        {
            if (string.IsNullOrEmpty(token.Token))
                return false;

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var key = Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value);

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                var claimsPrincipal = tokenHandler.ValidateToken(token.Token, validationParameters, out var rawValidatedToken);

                return true;
            }
            catch (SecurityTokenValidationException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}
