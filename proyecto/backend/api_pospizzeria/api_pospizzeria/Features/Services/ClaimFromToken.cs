using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace api_pospizzeria.Features.Services
{
    public class ClaimFromToken
    {
        private IConfiguration config;

        public ClaimFromToken(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<string> GetClaimFromToken(string token, string claimType)
        {
            if (string.IsNullOrEmpty(token))
            {
                return "El token está vacío o es nulo.";
            }

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

                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out var rawValidatedToken);

                if (claimsPrincipal == null)
                {
                    return "ClaimsPrincipal es nulo, el token no pudo ser validado.";
                }

                var claim = claimsPrincipal.FindFirst(claimType)?.Value;

                if (string.IsNullOrEmpty(claim))
                {
                    return $"No se encontró el Claim '{claimType}' en el token.";
                }

                return claim;
            }
            catch (SecurityTokenValidationException ex)
            {
                return $"Error de validación del token: {ex.Message}";
            }
            catch (ArgumentException ex)
            {
                return $"Error de argumento: {ex.Message}";
            }
        }

    }

}
