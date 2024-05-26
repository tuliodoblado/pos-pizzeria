using Microsoft.AspNetCore.Mvc;
using api_pospizzeria.Features.FOprt;
using api_pospizzeria.Features.FOprt.Dtos;
using System.Threading.Tasks;

namespace api_pospizzeria.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class OprtController : ControllerBase
    {
        private readonly IOprtService _oprtService;

        public OprtController(IOprtService oprtService)
        {
            _oprtService = oprtService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _oprtService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("specific")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _oprtService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(OprtDto oprtDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CreatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var createdProduct = await _oprtService.CreateProductAsync(oprtDto, CreatedBy);

            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateProduct(OprtDto oprtDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UpdatedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var updatedProduct = await _oprtService.UpdateProductAsync(oprtDto, UpdatedBy);

            if (updatedProduct == null)
            {
                return NotFound($"Product with ID {oprtDto.Id} not found.");
            }
            return Ok(updatedProduct);
        }

        [HttpPut]
        [Route("delete")]
        public async Task<IActionResult> LogicalDeleteProduct(int id)
        {
            var DeletedBy = Convert.ToInt32(HttpContext.Items["UserId"] as string);

            var success = await _oprtService.LogicalDeleteProductAsync(id, DeletedBy);

            if (!success)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/kill")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var success = await _oprtService.DeleteProductAsync(id);

            if (!success)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
