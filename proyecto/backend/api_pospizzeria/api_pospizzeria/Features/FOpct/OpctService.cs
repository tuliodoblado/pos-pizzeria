using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;
using api_pospizzeria.Features.FOpct.Dtos;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOpct
{
    public class OpctService : IOpctService
    {
        private readonly DB01_ApiContext _context;
        private readonly IMapper _mapper;

        public OpctService(DB01_ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OpctDto>> GetAllCategoriesAsync()
        {
            var categories = await _context.Opct
                                           .AsNoTracking()
                                           .Where(c => c.DeletedStatus != true)
                                           .ToListAsync();
            return _mapper.Map<IEnumerable<OpctDto>>(categories);
        }

        public async Task<OpctDto> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Opct.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return category != null ? _mapper.Map<OpctDto>(category) : null;
        }

        public async Task<OpctDto> CreateCategoryAsync(OpctDto opctDto, int CreatedBy)
        {
            var category = _mapper.Map<Opct>(opctDto);

            category.DateCreated = DateTime.Now;
            category.CreatedBy = CreatedBy;

            _context.Opct.Add(category);

            await _context.SaveChangesAsync();

            return _mapper.Map<OpctDto>(category);
        }

        public async Task<OpctDto> UpdateCategoryAsync(OpctDto opctDto, int UpdatedBy)
        {
            var category = await _context.Opct.FindAsync(opctDto.Id);

            if (category == null) return null;

            _mapper.Map(opctDto, category);
            category.UpdatedBy = UpdatedBy;
            category.DateUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return _mapper.Map<OpctDto>(category);
        }

        public async Task<bool> LogicalDeleteCategoryAsync(int id, int DeletedBy)
        {
            var category = await _context.Opct.FindAsync(id);

            if (category == null) return false;

            category.DeletedStatus = true;
            category.DeletedBy = DeletedBy;
            category.DateDeleted = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Opct.FindAsync(id);

            if (category == null) return false;
            _context.Opct.Remove(category);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
