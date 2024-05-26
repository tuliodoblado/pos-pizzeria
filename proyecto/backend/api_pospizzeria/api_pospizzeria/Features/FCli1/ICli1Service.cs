using api_pospizzeria.Features.FCli1.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FCli1
{
    public interface ICli1Service
    {
        Task<IEnumerable<Cli1Dto>> GetAllAddressesAsync();
        Task<Cli1Dto> GetAddressByIdAsync(int id);
        Task<Cli1Dto> CreateAddressAsync(Cli1Dto cli1Dto, int CreatedBy);
        Task<Cli1Dto> UpdateAddressAsync(Cli1Dto cli1Dto, int UpdatedBy);
        Task<bool> LogicalDeleteAddressAsync(int id, int DeletedBy);
        Task<bool> DeleteAddressAsync(int id);
    }
}
