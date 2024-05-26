using Microsoft.AspNetCore.Mvc;
using api_pospizzeria.Features.FOrol;
using api_pospizzeria.Features.FOrol.Dtos;

namespace api_pospizzeria.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class OrolController : ControllerBase
    {
        private readonly IOrolService _orolService;

        public OrolController(IOrolService orolService)
        {
            _orolService = orolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _orolService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet]
        [Route("rolespecific")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _orolService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound($"Role with ID {id} not found.");
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(OrolDto orolDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CreatedBy = Convert.ToInt32(HttpContext.Items["Iduser"] as string);

            var createdRole = await _orolService.CreateRoleAsync(orolDto, CreatedBy);

            return CreatedAtAction(nameof(GetRoleById), new { id = createdRole.Id }, createdRole);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateRole(OrolDto orolDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UpdateBy = Convert.ToInt32(HttpContext.Items["Iduser"] as string);

            var updatedRole = await _orolService.UpdateRoleAsync(orolDto, UpdateBy);
            if (updatedRole == null)
            {
                return NotFound($"Role with ID {orolDto.Id} not found.");
            }
            return Ok(updatedRole);
        }

        [HttpPut]
        [Route("delete")]
        public async Task<IActionResult> LogicalDelete(OrolDto orolDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var DeleteBy = Convert.ToInt32(HttpContext.Items["Iduser"] as string);

            var deleteRole = await _orolService.LogicalDeleteRoleAsync(orolDto, DeleteBy);
            if (deleteRole == null)
            {
                return NotFound($"Role with ID {orolDto.Id} not found.");
            }
            return Ok();
        }

        [HttpDelete]
        [Route("delete/kill")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var success = await _orolService.DeleteRoleRightAsync(id);
            if (!success)
            {
                return NotFound($"Role with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
