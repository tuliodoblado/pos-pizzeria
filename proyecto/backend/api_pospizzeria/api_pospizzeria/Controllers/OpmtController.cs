using Microsoft.AspNetCore.Mvc;
using api_pospizzeria.Features.FOpmt;
using api_pospizzeria.Features.FOpmt.Dtos;
using System.Threading.Tasks;

namespace api_pospizzeria.Controllers
{
    [ApiController]
    [Route("api/paymentmethods")]
    public class OpmtController : ControllerBase
    {
        private readonly IOpmtService _opmtService;

        public OpmtController(IOpmtService opmtService)
        {
            _opmtService = opmtService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaymentMethods()
        {
            var paymentMethods = await _opmtService.GetAllPaymentMethodsAsync();
            return Ok(paymentMethods);
        }

        [HttpGet]
        [Route("specific")]
        public async Task<IActionResult> GetPaymentMethodById(int id)
        {
            var paymentMethod = await _opmtService.GetPaymentMethodByIdAsync(id);

            if (paymentMethod == null)
            {
                return NotFound($"Payment method with ID {id} not found.");
            }
            return Ok(paymentMethod);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentMethod(OpmtDto opmtDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CreatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var createdPaymentMethod = await _opmtService.CreatePaymentMethodAsync(opmtDto, CreatedBy);

            return CreatedAtAction(nameof(GetPaymentMethodById), new { id = createdPaymentMethod.Id }, createdPaymentMethod);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdatePaymentMethod(OpmtDto opmtDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UpdatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var updatedPaymentMethod = await _opmtService.UpdatePaymentMethodAsync(opmtDto, UpdatedBy);

            if (updatedPaymentMethod == null)
            {
                return NotFound($"Payment method with ID {opmtDto.Id} not found.");
            }
            return Ok(updatedPaymentMethod);
        }

        [HttpPut]
        [Route("delete")]
        public async Task<IActionResult> LogicalDeletePaymentMethod(int id)
        {
            var DeletedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var success = await _opmtService.LogicalDeletePaymentMethodAsync(id, DeletedBy);

            if (!success)
            {
                return NotFound($"Payment method with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/kill")]
        public async Task<IActionResult> DeletePaymentMethod(int id)
        {
            var success = await _opmtService.DeletePaymentMethodAsync(id);

            if (!success)
            {
                return NotFound($"Payment method with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
