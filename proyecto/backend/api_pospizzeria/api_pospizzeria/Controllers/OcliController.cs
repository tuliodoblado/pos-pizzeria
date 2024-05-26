using Microsoft.AspNetCore.Mvc;
using api_pospizzeria.Features.FOcli;
using api_pospizzeria.Features.FOcli.Dtos;
using System.Threading.Tasks;

namespace api_pospizzeria.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class OcliController : ControllerBase
    {
        private readonly IOcliService _ocliService;

        public OcliController(IOcliService ocliService)
        {
            _ocliService = ocliService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _ocliService.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpGet]
        [Route("specific")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _ocliService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound($"Client with ID {id} not found.");
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(OcliDto ocliDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CreatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var createdClient = await _ocliService.CreateClientAsync(ocliDto, CreatedBy);

            return CreatedAtAction(nameof(GetClientById), new { id = createdClient.Id }, createdClient);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateClient(OcliDto ocliDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UpdatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var updatedClient = await _ocliService.UpdateClientAsync(ocliDto, UpdatedBy);

            if (updatedClient == null)
            {
                return NotFound($"Client with ID {ocliDto.Id} not found.");
            }
            return Ok(updatedClient);
        }

        [HttpPut]
        [Route("delete")]
        public async Task<IActionResult> LogicalDeleteClient(int id)
        {
            var DeletedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var success = await _ocliService.LogicalDeleteClientAsync(id, DeletedBy);

            if (!success)
            {
                return NotFound($"Client with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/kill")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var success = await _ocliService.DeleteClientAsync(id);

            if (!success)
            {
                return NotFound($"Client with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
