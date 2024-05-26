using Microsoft.AspNetCore.Mvc;
using api_pospizzeria.Features.FOusr;
using api_pospizzeria.Features.FOusr.Dtos;
using System.Threading.Tasks;

namespace api_pospizzeria.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class OusrController : ControllerBase
    {
        private readonly IOusrService _ousrService;

        public OusrController(IOusrService ousrService)
        {
            _ousrService = ousrService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _ousrService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("userspecific")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _ousrService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(OusrDto ousrDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CreatedBy = Convert.ToInt32(HttpContext.Items["Iduser"] as string);

            var createdUser = await _ousrService.CreateUserAsync(ousrDto, CreatedBy);

            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUser(OusrDto ousrDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UpdateBy = Convert.ToInt32(HttpContext.Items["Iduser"] as string);

            var updatedUser = await _ousrService.UpdateUserAsync(ousrDto, UpdateBy);
            if (updatedUser == null)
            {
                return NotFound($"User with ID {ousrDto.Id} not found.");
            }
            return Ok(updatedUser);
        }

        [HttpPut]
        [Route("delete")]
        public async Task<IActionResult> LogicalDeleteUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var DeleteBy = Convert.ToInt32(HttpContext.Items["Iduser"] as string);

            var deleteUser = await _ousrService.LogicalDeleteUserAsync(id, DeleteBy);
            if (!deleteUser)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/kill")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _ousrService.DeleteUserAsync(id);
            if (!success)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
