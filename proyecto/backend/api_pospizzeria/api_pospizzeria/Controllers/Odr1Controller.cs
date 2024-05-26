using Microsoft.AspNetCore.Mvc;
using api_pospizzeria.Features.FOdr1;
using api_pospizzeria.Features.FOdr1.Dtos;
using System.Threading.Tasks;

namespace api_pospizzeria.Controllers
{
    [ApiController]
    [Route("api/orderdetails")]
    public class Odr1Controller : ControllerBase
    {
        private readonly IOdr1Service _odr1Service;

        public Odr1Controller(IOdr1Service odr1Service)
        {
            _odr1Service = odr1Service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            var details = await _odr1Service.GetAllOrderDetailsAsync();
            return Ok(details);
        }

        [HttpGet]
        [Route("specific")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var detail = await _odr1Service.GetOrderDetailByIdAsync(id);

            if (detail == null)
            {
                return NotFound($"Order detail with ID {id} not found.");
            }
            return Ok(detail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(Odr1Dto odr1Dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CreatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var createdDetail = await _odr1Service.CreateOrderDetailAsync(odr1Dto, CreatedBy);

            return CreatedAtAction(nameof(GetOrderDetailById), new { id = createdDetail.Id }, createdDetail);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateOrderDetail(Odr1Dto odr1Dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UpdatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var updatedDetail = await _odr1Service.UpdateOrderDetailAsync(odr1Dto, UpdatedBy);

            if (updatedDetail == null)
            {
                return NotFound($"Order detail with ID {odr1Dto.Id} not found.");
            }
            return Ok(updatedDetail);
        }

        [HttpPut]
        [Route("delete")]
        public async Task<IActionResult> LogicalDeleteOrderDetail(int id)
        {
            var DeletedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var success = await _odr1Service.LogicalDeleteOrderDetailAsync(id, DeletedBy);

            if (!success)
            {
                return NotFound($"Order detail with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/kill")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var success = await _odr1Service.DeleteOrderDetailAsync(id);

            if (!success)
            {
                return NotFound($"Order detail with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
