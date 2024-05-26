using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;
using api_pospizzeria.Features.FOinv.Dtos;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOinv
{
    public class OinvService : IOinvService
    {
        private readonly DB01_ApiContext _context;
        private readonly IMapper _mapper;

        public OinvService(DB01_ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OinvDto>> GetAllInvoicesAsync()
        {
            var invoices = await _context.Oinv
                                         .AsNoTracking()
                                         .Where(i => i.DeletedStatus != true)
                                         .ToListAsync();
            return _mapper.Map<IEnumerable<OinvDto>>(invoices);
        }

        public async Task<OinvDto> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _context.Oinv
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(i => i.Id == id && i.DeletedStatus != true);
            return invoice != null ? _mapper.Map<OinvDto>(invoice) : null;
        }

        public async Task<OinvDto> CreateInvoiceAsync(OinvDto oinvDto, int CreatedBy)
        {
            var invoice = _mapper.Map<Oinv>(oinvDto);

            invoice.DateCreated = DateTime.Now;
            invoice.CreatedBy = CreatedBy;

            _context.Oinv.Add(invoice);
            await _context.SaveChangesAsync();

            return _mapper.Map<OinvDto>(invoice);
        }

        public async Task<OinvDto> UpdateInvoiceAsync(OinvDto oinvDto, int UpdatedBy)
        {
            var invoice = await _context.Oinv.FindAsync(oinvDto.Id);

            if (invoice == null) return null;

            _mapper.Map(oinvDto, invoice);

            invoice.UpdatedBy = UpdatedBy;
            invoice.DateUpdated = DateTime.Now;
            await _context.SaveChangesAsync();

            return _mapper.Map<OinvDto>(invoice);
        }

        public async Task<bool> LogicalDeleteInvoiceAsync(int id, int DeletedBy)
        {
            var invoice = await _context.Oinv.FindAsync(id);

            if (invoice == null) return false;

            invoice.DeletedStatus = true;
            invoice.DeletedBy = DeletedBy;
            invoice.DateDeleted = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteInvoiceAsync(int id)
        {
            var invoice = await _context.Oinv.FindAsync(id);

            if (invoice == null) return false;

            _context.Oinv.Remove(invoice);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
