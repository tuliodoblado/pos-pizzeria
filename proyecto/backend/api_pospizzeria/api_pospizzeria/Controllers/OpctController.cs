using Microsoft.AspNetCore.Mvc;
using api_pospizzeria.Features.FOpct;
using api_pospizzeria.Features.FOpct.Dtos;
using System.Threading.Tasks;

namespace api_pospizzeria.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class OpctController : ControllerBase
    {
        private readonly IOpctService _opctService;

        public OpctController(IOpctService opctService)
        {
            _opctService = opctService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _opctService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("specific")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _opctService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(OpctDto opctDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CreatedBy = Convert.ToInt32(HttpContext.Items["Iduser"] as string);

            var createdCategory = await _opctService.CreateCategoryAsync(opctDto, CreatedBy);

            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut]
        [Route("update")]

        public async Task<IActionResult> UpdateCategory(OpctDto opctDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UpdatedBy = Convert.ToInt32(HttpContext.Items["Iduser"] as string);

            var updatedCategory = await _opctService.UpdateCategoryAsync(opctDto, UpdatedBy);

            if (updatedCategory == null)
            {
                return NotFound($"Category with ID {opctDto.Id} not found.");
            }
            return Ok(updatedCategory);
        }

        [HttpPut]
        [Route("delete")]
        public async Task<IActionResult> LogicalDeleteCategory(int id)
        {
            var DeleteBy = Convert.ToInt32(HttpContext.Items["Iduser"] as string);

            var success = await _opctService.LogicalDeleteCategoryAsync(id, DeleteBy);

            if (!success)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/kill")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var success = await _opctService.DeleteCategoryAsync(id);
            if (!success)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
