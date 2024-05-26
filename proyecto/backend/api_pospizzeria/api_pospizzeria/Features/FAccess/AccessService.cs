using api_pospizzeria.Features.FAccess.Dtos;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;
using Microsoft.EntityFrameworkCore;
using api_pospizzeria.Features.Services;

namespace api_pospizzeria.Features.FAccess
{
    public class AccessService : IAccessService
    {
        private readonly DB01_ApiContext _applicationDbContext;
        private readonly PasswordService _passwordService;
        private readonly GenerateToken _generateToken;

        public AccessService(DB01_ApiContext applicationDbContext, PasswordService passwordService, GenerateToken generateToken)
        {
            _applicationDbContext = applicationDbContext;
            _passwordService = passwordService;
            _generateToken = generateToken;
        }

        public async Task<string> AuthenticateAsync(AccessDto loginRequest)
        {
            try
            {
                var inputUsername = loginRequest.NameUser.ToLower();

                var usuario = await _applicationDbContext.Ousr
                    .AsQueryable()
                    .Where(u => u.NameUser.ToLower() == inputUsername)
                    .FirstOrDefaultAsync();

                // Si el usuario existe y la contraseña verifica correctamente loguin exitoso
                if (usuario != null && _passwordService.VerifyPassword(loginRequest.Password, usuario.Password))
                {
                    return _generateToken.CreateToken(usuario);
                }
                else
                {
                    throw new Exception("Nombre de usuario o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
    }
}
