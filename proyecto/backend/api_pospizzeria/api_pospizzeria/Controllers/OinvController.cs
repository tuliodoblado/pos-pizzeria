using Microsoft.AspNetCore.Mvc;
using api_pospizzeria.Features.FOinv;
using api_pospizzeria.Features.FOinv.Dtos;
using System.Threading.Tasks;

namespace api_pospizzeria.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class OinvController : ControllerBase
    {
        private readonly IOinvService _oinvService;

        public OinvController(IOinvService oinvService)
        {
            _oinvService = oinvService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _oinvService.GetAllInvoicesAsync();
            return Ok(invoices);
        }

        [HttpGet]
        [Route("specific")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var invoice = await _oinvService.GetInvoiceByIdAsync(id);

            if (invoice == null)
            {
                return NotFound($"Invoice with ID {id} not found.");
            }
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice(OinvDto oinvDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CreatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var createdInvoice = await _oinvService.CreateInvoiceAsync(oinvDto, CreatedBy);

            return CreatedAtAction(nameof(GetInvoiceById), new { id = createdInvoice.Id }, createdInvoice);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateInvoice(OinvDto oinvDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UpdatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var updatedInvoice = await _oinvService.UpdateInvoiceAsync(oinvDto, UpdatedBy);

            if (updatedInvoice == null)
            {
                return NotFound($"Invoice with ID {oinvDto.Id} not found.");
            }
            return Ok(updatedInvoice);
        }

        [HttpPut]
        [Route("delete")]
        public async Task<IActionResult> LogicalDeleteInvoice(int id)
        {
            var DeletedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var success = await _oinvService.LogicalDeleteInvoiceAsync(id, DeletedBy);

            if (!success)
            {
                return NotFound($"Invoice with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/kill")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var success = await _oinvService.DeleteInvoiceAsync(id);

            if (!success)
            {
                return NotFound($"Invoice with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
