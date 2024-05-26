using Microsoft.AspNetCore.Mvc;
using api_pospizzeria.Features.FOodr;
using api_pospizzeria.Features.FOodr.Dtos;
using System.Threading.Tasks;

namespace api_pospizzeria.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OodrController : ControllerBase
    {
        private readonly IOodrService _oodrService;

        public OodrController(IOodrService oodrService)
        {
            _oodrService = oodrService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _oodrService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet]
        [Route("specific")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _oodrService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OodrDto oodrDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CreatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var createdOrder = await _oodrService.CreateOrderAsync(oodrDto, CreatedBy);

            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateOrder(OodrDto oodrDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UpdatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var updatedOrder = await _oodrService.UpdateOrderAsync(oodrDto, UpdatedBy);

            if (updatedOrder == null)
            {
                return NotFound($"Order with ID {oodrDto.Id} not found.");
            }
            return Ok(updatedOrder);
        }

        [HttpPut]
        [Route("delete")]
        public async Task<IActionResult> LogicalDeleteOrder(int id)
        {
            var DeletedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var success = await _oodrService.LogicalDeleteOrderAsync(id, DeletedBy);

            if (!success)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/kill")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var success = await _oodrService.DeleteOrderAsync(id);

            if (!success)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
