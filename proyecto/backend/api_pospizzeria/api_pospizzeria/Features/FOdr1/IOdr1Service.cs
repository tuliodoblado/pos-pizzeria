using api_pospizzeria.Features.FOdr1.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOdr1
{
    public interface IOdr1Service
    {
        Task<IEnumerable<Odr1Dto>> GetAllOrderDetailsAsync();
        Task<Odr1Dto> GetOrderDetailByIdAsync(int id);
        Task<Odr1Dto> CreateOrderDetailAsync(Odr1Dto odr1Dto, int CreatedBy);
        Task<Odr1Dto> UpdateOrderDetailAsync(Odr1Dto odr1Dto, int UpdatedBy);
        Task<bool> LogicalDeleteOrderDetailAsync(int id, int DeletedBy);
        Task<bool> DeleteOrderDetailAsync(int id);
    }
}
