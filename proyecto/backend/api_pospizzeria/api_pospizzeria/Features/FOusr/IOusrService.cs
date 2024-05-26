using api_pospizzeria.Features.FOusr.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOusr
{
    public interface IOusrService
    {
        Task<IEnumerable<OusrDto>> GetAllUsersAsync();
        Task<OusrDto> GetUserByIdAsync(int id);
        Task<OusrDto> CreateUserAsync(OusrDto ousrDto, int CreatedBy);
        Task<OusrDto> UpdateUserAsync(OusrDto ouschDto, int UpdatedBy);
        Task<bool> LogicalDeleteUserAsync(int id, int DeletedBy);
        Task<bool> DeleteUserAsync(int id);
    }
}
