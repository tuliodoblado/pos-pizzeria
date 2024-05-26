using BCrypt.Net; 
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;

namespace api_pospizzeria.Features.Services
{
    public class PasswordService
    {
        private readonly DB01_ApiContext _dbContext;

        public PasswordService(DB01_ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Hashing de la contraseña
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password); 
        }

        // Verificación de la contraseña
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword); 
        }

        // Cambio de contraseña
        public async Task<bool> ChangePasswordAsync(int userId , string newPassword)
        {
            var user = await _dbContext.Ousr.FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                user.Password = HashPassword(newPassword);
                _dbContext.Entry(user).Property(u => u.Password).IsModified = true;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
