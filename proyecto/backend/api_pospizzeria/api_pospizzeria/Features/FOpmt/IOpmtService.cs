using api_pospizzeria.Features.FOpmt.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOpmt
{
    public interface IOpmtService
    {
        Task<IEnumerable<OpmtDto>> GetAllPaymentMethodsAsync();
        Task<OpmtDto> GetPaymentMethodByIdAsync(int id);
        Task<OpmtDto> CreatePaymentMethodAsync(OpmtDto opmtDto, int CreatedBy);
        Task<OpmtDto> UpdatePaymentMethodAsync(OpmtDto opmtDto, int UpdatedBy);
        Task<bool> LogicalDeletePaymentMethodAsync(int id, int DeletedBy);
        Task<bool> DeletePaymentMethodAsync(int id);
    }
}
