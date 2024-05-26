using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;
using api_pospizzeria.Features.FOprt.Dtos;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOprt
{
    public class OprtService : IOprtService
    {
        private readonly DB01_ApiContext _context;
        private readonly IMapper _mapper;

        public OprtService(DB01_ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OprtDto>> GetAllProductsAsync()
        {
            var products = await _context.Oprt
                                         .AsNoTracking()
                                         .Where(p => p.DeletedStatus != true)
                                         .ToListAsync();
            return _mapper.Map<IEnumerable<OprtDto>>(products);
        }

        public async Task<OprtDto> GetProductByIdAsync(int id)
        {
            var product = await _context.Oprt.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            return product != null ? _mapper.Map<OprtDto>(product) : null;
        }

        public async Task<OprtDto> CreateProductAsync(OprtDto oprtDto, int CreatedBy)
        {
            var product = _mapper.Map<Oprt>(oprtDto);

            product.DateCreated = DateTime.Now;
            product.CreatedBy = CreatedBy;

            _context.Oprt.Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<OprtDto>(product);
        }

        public async Task<OprtDto> UpdateProductAsync(OprtDto oprtDto, int UpdatedBy)
        {
            var product = await _context.Oprt.FindAsync(oprtDto.Id);

            if (product == null) return null;

            _mapper.Map(oprtDto, product);

            product.UpdatedBy = UpdatedBy;
            product.DateUpdated = DateTime.Now;
            await _context.SaveChangesAsync();

            return _mapper.Map<OprtDto>(product);
        }

        public async Task<bool> LogicalDeleteProductAsync(int id, int DeletedBy)
        {
            var product = await _context.Oprt.FindAsync(id);

            if (product == null) return false;

            product.DeletedStatus = true;
            product.DeletedBy = DeletedBy;
            product.DateDeleted = DateTime.Now;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Oprt.FindAsync(id);

            if (product == null) return false;

            _context.Oprt.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
