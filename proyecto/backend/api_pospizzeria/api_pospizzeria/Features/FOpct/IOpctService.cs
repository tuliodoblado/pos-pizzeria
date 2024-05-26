using api_pospizzeria.Features.FOpct.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOpct
{
    public interface IOpctService
    {
        Task<IEnumerable<OpctDto>> GetAllCategoriesAsync();
        Task<OpctDto> GetCategoryByIdAsync(int id);
        Task<OpctDto> CreateCategoryAsync(OpctDto opctDto, int CreatedBy);
        Task<OpctDto> UpdateCategoryAsync(OpctDto opctDto, int UpdatedBy);
        Task<bool> LogicalDeleteCategoryAsync(int id, int DeletedBy);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
