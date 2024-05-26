using Microsoft.AspNetCore.Mvc;
using api_pospizzeria.Features.FCli1;
using api_pospizzeria.Features.FCli1.Dtos;
using System.Threading.Tasks;

namespace api_pospizzeria.Controllers
{
    [ApiController]
    [Route("api/customeraddresses")]
    public class Cli1Controller : ControllerBase
    {
        private readonly ICli1Service _cli1Service;

        public Cli1Controller(ICli1Service cli1Service)
        {
            _cli1Service = cli1Service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            var addresses = await _cli1Service.GetAllAddressesAsync();
            return Ok(addresses);
        }

        [HttpGet]
        [Route("specific")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var address = await _cli1Service.GetAddressByIdAsync(id);
            if (address == null)
            {
                return NotFound($"Address with ID {id} not found.");
            }
            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(Cli1Dto cli1Dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CreatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var createdAddress = await _cli1Service.CreateAddressAsync(cli1Dto, CreatedBy);

            return CreatedAtAction(nameof(GetAddressById), new { id = createdAddress.Id }, createdAddress);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAddress(Cli1Dto cli1Dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UpdatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var updatedAddress = await _cli1Service.UpdateAddressAsync(cli1Dto, UpdatedBy);

            if (updatedAddress == null)
            {
                return NotFound($"Address with ID {cli1Dto.Id} not found.");
            }
            return Ok(updatedAddress);
        }

        [HttpPut]
        [Route("delete")]
        public async Task<IActionResult> LogicalDeleteAddress(int id)
        {
            var DeletedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var success = await _cli1Service.LogicalDeleteAddressAsync(id, DeletedBy);

            if (!success)
            {
                return NotFound($"Address with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/kill")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var success = await _cli1Service.DeleteAddressAsync(id);

            if (!success)
            {
                return NotFound($"Address with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
