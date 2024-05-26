using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;
using api_pospizzeria.Features.FOrol.Dtos;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOrol
{
    public class OrolService : IOrolService
    {
        private readonly DB01_ApiContext _context;
        private readonly IMapper _mapper;

        public OrolService(DB01_ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrolDto>> GetAllRolesAsync()
        {
            var roles = await _context.Orol
                                      .AsNoTracking()
                                      .Where(r => r.DeletedStatus != true)
                                      .ToListAsync();
            var rolesDto = _mapper.Map<IEnumerable<OrolDto>>(roles);
            return rolesDto;
        }

        public async Task<OrolDto> GetRoleByIdAsync(int id)
        {
            var role = await _context.Orol.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            if (role == null)
            {
                return null;
            }
            else
            {
                var roleDto = _mapper.Map<OrolDto>(role);
                return roleDto;
            }
        }

        public async Task<OrolDto> CreateRoleAsync(OrolDto orolDto, int CreatedBy)
        {
            var role = _mapper.Map<Orol>(orolDto);

            role.Status = true;
            role.CreatedBy = CreatedBy;
            role.DateCreated = DateTime.Now;
            _context.Orol.Add(role);

            await _context.SaveChangesAsync();
            var newrol = _mapper.Map<OrolDto>(role);

            return newrol;
        }

        public async Task<OrolDto> UpdateRoleAsync(OrolDto orolDto, int UpdateBy)
        {
            var role = await _context.Orol.FirstOrDefaultAsync(r => r.Id == orolDto.Id);
            if (role == null) return null;

            _mapper.Map(orolDto, role);

            role.UpdatedBy = UpdateBy;
            role.DateUpdated = DateTime.Now;

            await _context.SaveChangesAsync();
            var updatedRole = _mapper.Map<OrolDto>(role);

            return updatedRole;
        }

        public async Task<OrolDto> LogicalDeleteRoleAsync(OrolDto orolDto, int DeleteBy)
        {
            var role = await _context.Orol.FirstOrDefaultAsync(r => r.Id == orolDto.Id);
            if (role == null) return null;

            role.DeletedStatus = true;
            role.DeletedBy = DeleteBy;
            role.DateDeleted = DateTime.Now;

            await _context.SaveChangesAsync();
            var deletedRole = _mapper.Map<OrolDto>(role);

            return deletedRole;
        }

        public async Task<bool> DeleteRoleRightAsync(int id)
        {
            var role = await _context.Orol.FindAsync(id);
            if (role == null) return false;

            _context.Orol.Remove(role);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
