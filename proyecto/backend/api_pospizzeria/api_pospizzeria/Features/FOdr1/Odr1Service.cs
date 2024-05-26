using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;
using api_pospizzeria.Features.FOdr1.Dtos;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOdr1
{
    public class Odr1Service : IOdr1Service
    {
        private readonly DB01_ApiContext _context;
        private readonly IMapper _mapper;

        public Odr1Service(DB01_ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Odr1Dto>> GetAllOrderDetailsAsync()
        {
            var details = await _context.Odr1
                                        .AsNoTracking()
                                        .Where(d => d.DeletedStatus != true)
                                        .ToListAsync();
            return _mapper.Map<IEnumerable<Odr1Dto>>(details);
        }

        public async Task<Odr1Dto> GetOrderDetailByIdAsync(int id)
        {
            var detail = await _context.Odr1
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(d => d.Id == id && d.DeletedStatus != true);
            return detail != null ? _mapper.Map<Odr1Dto>(detail) : null;
        }

        public async Task<Odr1Dto> CreateOrderDetailAsync(Odr1Dto odr1Dto, int CreatedBy)
        {
            var detail = _mapper.Map<Odr1>(odr1Dto);

            detail.DateCreated = DateTime.Now;
            detail.CreatedBy = CreatedBy;

            _context.Odr1.Add(detail);
            await _context.SaveChangesAsync();

            return _mapper.Map<Odr1Dto>(detail);
        }

        public async Task<Odr1Dto> UpdateOrderDetailAsync(Odr1Dto odr1Dto, int UpdatedBy)
        {
            var detail = await _context.Odr1.FindAsync(odr1Dto.Id);

            if (detail == null) return null;

            _mapper.Map(odr1Dto, detail);

            detail.UpdatedBy = UpdatedBy;
            detail.DateUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return _mapper.Map<Odr1Dto>(detail);
        }

        public async Task<bool> LogicalDeleteOrderDetailAsync(int id, int DeletedBy)
        {
            var detail = await _context.Odr1.FindAsync(id);

            if (detail == null) return false;

            detail.DeletedStatus = true;
            detail.DeletedBy = DeletedBy;
            detail.DateDeleted = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteOrderDetailAsync(int id)
        {
            var detail = await _context.Odr1.FindAsync(id);

            if (detail == null) return false;

            _context.Odr1.Remove(detail);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
