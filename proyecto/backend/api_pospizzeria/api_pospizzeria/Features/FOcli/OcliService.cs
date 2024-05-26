using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria;
using api_pospizzeria.Features.FOcli.Dtos;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_pospizzeria.Features.FOcli
{
    public class OcliService : IOcliService
    {
        private readonly DB01_ApiContext _context;
        private readonly IMapper _mapper;

        public OcliService(DB01_ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OcliDto>> GetAllClientsAsync()
        {
            var clients = await _context.Ocli
                                        .AsNoTracking()
                                        .Where(c => c.DeletedStatus != true)
                                        .ToListAsync();
            return _mapper.Map<IEnumerable<OcliDto>>(clients);
        }

        public async Task<OcliDto> GetClientByIdAsync(int id)
        {
            var client = await _context.Ocli.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            return client != null ? _mapper.Map<OcliDto>(client) : null;
        }

        public async Task<OcliDto> CreateClientAsync(OcliDto ocliDto, int CreatedBy)
        {
            var client = _mapper.Map<Ocli>(ocliDto);

            client.DateCreated = DateTime.Now;
            client.CreatedBy = CreatedBy;
            _context.Ocli.Add(client);
            await _context.SaveChangesAsync();

            return _mapper.Map<OcliDto>(client);
        }

        public async Task<OcliDto> UpdateClientAsync(OcliDto ocliDto, int UpdatedBy)
        {
            var client = await _context.Ocli.FindAsync(ocliDto.Id);

            if (client == null) return null;

            _mapper.Map(ocliDto, client);
            client.UpdatedBy = UpdatedBy;
            client.DateUpdated = DateTime.Now;
            await _context.SaveChangesAsync();

            return _mapper.Map<OcliDto>(client);
        }

        public async Task<bool> LogicalDeleteClientAsync(int id, int DeletedBy)
        {
            var client = await _context.Ocli.FindAsync(id);

            if (client == null) return false;

            client.DeletedStatus = true;
            client.DeletedBy = DeletedBy;
            client.DateDeleted = DateTime.Now;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await _context.Ocli.FindAsync(id);

            if (client == null) return false;

            _context.Ocli.Remove(client);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
