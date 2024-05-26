using api_pospizzeria.Features.FAccess;
using api_pospizzeria.Features.Services;
using System.Security.Claims;

namespace api_pospizzeria.Infrastructure.Middlewares
{
    public class ExtractClaim
    {
        private readonly RequestDelegate _next;

        public ExtractClaim(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ClaimFromToken claimFromToken)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                // Obtener el token del encabezado de la solicitud
                var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                var emailClaim = await claimFromToken.GetClaimFromToken(token, ClaimTypes.UserData);
                var iduserClaim = await claimFromToken.GetClaimFromToken(token, ClaimTypes.SerialNumber);
                var roleClaim = await claimFromToken.GetClaimFromToken(token, ClaimTypes.Role);
                var nameClaim = await claimFromToken.GetClaimFromToken(token, ClaimTypes.Name);

                // Verificar si se encontró el Claim y añadirlo al contexto
                if (!string.IsNullOrEmpty(emailClaim) && !emailClaim.StartsWith("Error"))
                {
                    context.Items["Email"] = emailClaim;
                    context.Items["Iduser"] = iduserClaim;
                    context.Items["Role"] = roleClaim;
                    context.Items["Name"] = nameClaim;
                }
            }
            await _next(context);
        }
    }
}
