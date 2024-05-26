using api_pospizzeria.Features.FOprt.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOprt
{
    public interface IOprtService
    {
        Task<IEnumerable<OprtDto>> GetAllProductsAsync();
        Task<OprtDto> GetProductByIdAsync(int id);
        Task<OprtDto> CreateProductAsync(OprtDto oprtDto, int CreatedBy);
        Task<OprtDto> UpdateProductAsync(OprtDto oprtDto, int UpdatedBy);
        Task<bool> LogicalDeleteProductAsync(int id, int DeletedBy);
        Task<bool> DeleteProductAsync(int id);
    }
}
