using api_pospizzeria.Features.FOinv.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOinv
{
    public interface IOinvService
    {
        Task<IEnumerable<OinvDto>> GetAllInvoicesAsync();
        Task<OinvDto> GetInvoiceByIdAsync(int id);
        Task<OinvDto> CreateInvoiceAsync(OinvDto oinvDto, int CreatedBy);
        Task<OinvDto> UpdateInvoiceAsync(OinvDto oinvDto, int UpdatedBy);
        Task<bool> LogicalDeleteInvoiceAsync(int id, int DeletedBy);
        Task<bool> DeleteInvoiceAsync(int id);
    }
}
