using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;
using api_pospizzeria.Features.FOpmt.Dtos;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOpmt
{
    public class OpmtService : IOpmtService
    {
        private readonly DB01_ApiContext _context;
        private readonly IMapper _mapper;

        public OpmtService(DB01_ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OpmtDto>> GetAllPaymentMethodsAsync()
        {
            var paymentMethods = await _context.Opmt
                                               .AsNoTracking()
                                               .Where(pm => pm.DeletedStatus != true)
                                               .ToListAsync();
            return _mapper.Map<IEnumerable<OpmtDto>>(paymentMethods);
        }

        public async Task<OpmtDto> GetPaymentMethodByIdAsync(int id)
        {
            var paymentMethod = await _context.Opmt.AsNoTracking().FirstOrDefaultAsync(pm => pm.Id == id);

            return paymentMethod != null ? _mapper.Map<OpmtDto>(paymentMethod) : null;
        }

        public async Task<OpmtDto> CreatePaymentMethodAsync(OpmtDto opmtDto, int CreatedBy)
        {
            var paymentMethod = _mapper.Map<Opmt>(opmtDto);

            paymentMethod.DateCreated = DateTime.Now;
            paymentMethod.CreatedBy = CreatedBy;
            _context.Opmt.Add(paymentMethod);

            await _context.SaveChangesAsync();

            return _mapper.Map<OpmtDto>(paymentMethod);
        }

        public async Task<OpmtDto> UpdatePaymentMethodAsync(OpmtDto opmtDto, int UpdatedBy)
        {
            var paymentMethod = await _context.Opmt.FindAsync(opmtDto.Id);

            if (paymentMethod == null) return null;

            _mapper.Map(opmtDto, paymentMethod);
            paymentMethod.UpdatedBy = UpdatedBy;
            paymentMethod.DateUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return _mapper.Map<OpmtDto>(paymentMethod);
        }

        public async Task<bool> LogicalDeletePaymentMethodAsync(int id, int DeletedBy)
        {
            var paymentMethod = await _context.Opmt.FindAsync(id);

            if (paymentMethod == null) return false;

            paymentMethod.DeletedStatus = true;
            paymentMethod.DeletedBy = DeletedBy;
            paymentMethod.DateDeleted = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePaymentMethodAsync(int id)
        {
            var paymentMethod = await _context.Opmt.FindAsync(id);

            if (paymentMethod == null) return false;

            _context.Opmt.Remove(paymentMethod);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
