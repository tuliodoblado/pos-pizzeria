using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;
using api_pospizzeria.Features.FOusr.Dtos;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOusr
{
    public class OusrService : IOusrService
    {
        private readonly DB01_ApiContext _context;
        private readonly IMapper _mapper;

        public OusrService(DB01_ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OusrDto>> GetAllUsersAsync()
        {
            var users = await _context.Ousr
                                      .AsNoTracking()
                                      .Where(u => u.DeletedStatus != true)
                                      .ToListAsync();
            return _mapper.Map<IEnumerable<OusrDto>>(users);
        }

        public async Task<OusrDto> GetUserByIdAsync(int id)
        {
            var user = await _context.Ousr.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            return user != null ? _mapper.Map<OusrDto>(user) : null;
        }

        public async Task<OusrDto> CreateUserAsync(OusrDto ousrDto, int CreatedBy)
        {
            var user = _mapper.Map<Ousr>(ousrDto);
            user.Status = true;
            user.DateCreated = DateTime.Now;
            user.CreatedBy = CreatedBy;
            _context.Ousr.Add(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<OusrDto>(user);
        }

        public async Task<OusrDto> UpdateUserAsync(OusrDto ousrDto, int UpdatedBy)
        {
            var user = await _context.Ousr.FindAsync(ousrDto.Id);
            if (user == null) return null;
            _mapper.Map(ousrDto, user);
            user.UpdatedBy = UpdatedBy;
            user.DateUpdated = DateTime.Now;
            await _context.SaveChangesAsync();
            return _mapper.Map<OusrDto>(user);
        }

        public async Task<bool> LogicalDeleteUserAsync(int id, int DeletedBy)
        {
            var user = await _context.Ousr.FindAsync(id);
            if (user == null) return false;
            user.DeletedStatus = true;
            user.DeletedBy = DeletedBy;
            user.DateDeleted = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Ousr.FindAsync(id);
            if (user == null) return false;
            _context.Ousr.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
