using api_pospizzeria.Features.FOodr.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOodr
{
    public interface IOodrService
    {
        Task<IEnumerable<OodrDto>> GetAllOrdersAsync();
        Task<OodrDto> GetOrderByIdAsync(int id);
        Task<OodrDto> CreateOrderAsync(OodrDto oodrDto, int CreatedBy);
        Task<OodrDto> UpdateOrderAsync(OodrDto oodrDto, int UpdatedBy);
        Task<bool> LogicalDeleteOrderAsync(int id, int DeletedBy);
        Task<bool> DeleteOrderAsync(int id);
    }
}
