using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;
using api_pospizzeria.Features.FCli1.Dtos;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FCli1
{
    public class Cli1Service : ICli1Service
    {
        private readonly DB01_ApiContext _context;
        private readonly IMapper _mapper;

        public Cli1Service(DB01_ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cli1Dto>> GetAllAddressesAsync()
        {
            var addresses = await _context.Cli1
                                          .AsNoTracking()
                                          .Where(a => a.DeletedStatus != true)
                                          .ToListAsync();
            return _mapper.Map<IEnumerable<Cli1Dto>>(addresses);
        }

        public async Task<Cli1Dto> GetAddressByIdAsync(int id)
        {
            var address = await _context.Cli1
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(a => a.Id == id && a.DeletedStatus != true);
            return address != null ? _mapper.Map<Cli1Dto>(address) : null;
        }

        public async Task<Cli1Dto> CreateAddressAsync(Cli1Dto cli1Dto, int CreatedBy)
        {
            var address = _mapper.Map<Cli1>(cli1Dto);

            address.DateCreated = DateTime.Now;
            address.CreatedBy = CreatedBy;
            _context.Cli1.Add(address);
            await _context.SaveChangesAsync();

            return _mapper.Map<Cli1Dto>(address);
        }

        public async Task<Cli1Dto> UpdateAddressAsync(Cli1Dto cli1Dto, int UpdatedBy)
        {
            var address = await _context.Cli1.FindAsync(cli1Dto.Id);

            if (address == null) return null;

            _mapper.Map(cli1Dto, address);
            address.UpdatedBy = UpdatedBy;
            address.DateUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return _mapper.Map<Cli1Dto>(address);
        }

        public async Task<bool> LogicalDeleteAddressAsync(int id, int DeletedBy)
        {
            var address = await _context.Cli1.FindAsync(id);

            if (address == null) return false;

            address.DeletedStatus = true;
            address.DeletedBy = DeletedBy;
            address.DateDeleted = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAddressAsync(int id)
        {
            var address = await _context.Cli1.FindAsync(id);

            if (address == null) return false;

            _context.Cli1.Remove(address);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
