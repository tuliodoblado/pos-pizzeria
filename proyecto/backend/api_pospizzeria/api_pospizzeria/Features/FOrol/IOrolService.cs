using api_pospizzeria.Features.FOrol.Dtos;

namespace api_pospizzeria.Features.FOrol
{
    public interface IOrolService
    {
        Task<IEnumerable<OrolDto>> GetAllRolesAsync();
        Task<OrolDto> GetRoleByIdAsync(int id);
        Task<OrolDto> CreateRoleAsync(OrolDto orolDto, int CreatedBy);
        Task<OrolDto> UpdateRoleAsync(OrolDto orolDto, int UpdateBy);
        Task<OrolDto> LogicalDeleteRoleAsync(OrolDto orolDto, int DeleteBy);
        Task<bool> DeleteRoleRightAsync(int id);
    }
}
