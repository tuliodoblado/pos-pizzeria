using api_pospizzeria.Features.FOcli.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOcli
{
    public interface IOcliService
    {
        Task<IEnumerable<OcliDto>> GetAllClientsAsync();
        Task<OcliDto> GetClientByIdAsync(int id);
        Task<OcliDto> CreateClientAsync(OcliDto ocliDto, int CreatedBy);
        Task<OcliDto> UpdateClientAsync(OcliDto ocliDto, int UpdatedBy);
        Task<bool> LogicalDeleteClientAsync(int id, int DeletedBy);
        Task<bool> DeleteClientAsync(int id);
    }
}
