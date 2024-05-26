using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;
using api_pospizzeria.Features.FOodr.Dtos;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOodr
{
    public class OodrService : IOodrService
    {
        private readonly DB01_ApiContext _context;
        private readonly IMapper _mapper;

        public OodrService(DB01_ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OodrDto>> GetAllOrdersAsync()
        {
            var orders = await _context.Oodr
                                       .AsNoTracking()
                                       .Where(o => o.DeletedStatus != true)
                                       .ToListAsync();
            return _mapper.Map<IEnumerable<OodrDto>>(orders);
        }

        public async Task<OodrDto> GetOrderByIdAsync(int id)
        {
            var order = await _context.Oodr
                                      .AsNoTracking()
                                      .FirstOrDefaultAsync(o => o.Id == id && o.DeletedStatus != true);
            return order != null ? _mapper.Map<OodrDto>(order) : null;
        }

        public async Task<OodrDto> CreateOrderAsync(OodrDto oodrDto, int CreatedBy)
        {
            var order = _mapper.Map<Oodr>(oodrDto);

            order.DateCreated = DateTime.Now;
            order.CreatedBy = CreatedBy;

            _context.Oodr.Add(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<OodrDto>(order);
        }

        public async Task<OodrDto> UpdateOrderAsync(OodrDto oodrDto, int UpdatedBy)
        {
            var order = await _context.Oodr.FindAsync(oodrDto.Id);

            if (order == null) return null;

            _mapper.Map(oodrDto, order);

            order.UpdatedBy = UpdatedBy;
            order.DateUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return _mapper.Map<OodrDto>(order);
        }

        public async Task<bool> LogicalDeleteOrderAsync(int id, int DeletedBy)
        {
            var order = await _context.Oodr.FindAsync(id);

            if (order == null) return false;

            order.DeletedStatus = true;
            order.DeletedBy = DeletedBy;
            order.DateDeleted = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Oodr.FindAsync(id);

            if (order == null) return false;

            _context.Oodr.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
