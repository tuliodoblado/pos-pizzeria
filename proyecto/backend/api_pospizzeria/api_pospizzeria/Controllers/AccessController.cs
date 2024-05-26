using api_pospizzeria.Features.FAccess.Dtos;
using api_pospizzeria.Features.FAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using api_pospizzeria.Features.Services;

namespace api_pospizzeria.Controllers
{
    [ApiController]
    [Route("api/authenticate")]
    public class AccessController : ControllerBase
    {
        private readonly IAccessService _accessService;
        private readonly ValidateToken _validateToken;  
        public AccessController(IAccessService usuariosService, ValidateToken validateToken)
        {
            _accessService = usuariosService;
            _validateToken = validateToken;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate(AccessDto loginRequest)
        {
            try
            {
                var token = await _accessService.AuthenticateAsync(loginRequest);
                if (token != null)
                {
                    return Ok(new { user = loginRequest.NameUser, message = "Autenticación exitosa", token });
                }
                else
                {
                    return Unauthorized("Autenticación denegada");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("validatesession")]
        public async Task<IActionResult> ValidateToken()
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                if (string.IsNullOrEmpty(token))
                {
                    return BadRequest(new { message = "Token no proporcionado." });
                }

                var validatetoken = new ValidateDto { Token = token };
                var isValid = await _validateToken.MValidateToken(validatetoken);

                if (isValid)
                {
                    return Ok(new { active = true });
                }
                else
                {
                    return Unauthorized(new { active = false, message = "Token inválido." });
                }
            }
            catch (SecurityTokenValidationException stvEx)
            {
                return Unauthorized(new { active = false, message = stvEx.Message });
            }
            catch (ArgumentException argEx)
            {
                return BadRequest(new { message = argEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpGet]
        [Route("getactiveuser")]
        public async Task<ActionResult<IEnumerable<DataUserDto>>> GetClaim()
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                if (string.IsNullOrEmpty(token))
                {
                    return BadRequest(new { message = "Token no proporcionado." });
                }

                DataUserDto dataUserDto = new DataUserDto();

                dataUserDto.email = Convert.ToString(HttpContext.Items["Email"]) ?? "";
                dataUserDto.rol = Convert.ToInt32(HttpContext.Items["Role"]);
                dataUserDto.name = Convert.ToString(HttpContext.Items["Name"]) ?? "";


                if (dataUserDto.email != null && dataUserDto.rol != 0 && dataUserDto.name != null)
                {
                    return Ok(dataUserDto);
                }
                else
                {
                    return Unauthorized(new { active = false, message = "Token inválido." });
                }
            }
            catch (SecurityTokenValidationException stvEx)
            {
                return Unauthorized(new { active = false, message = stvEx.Message });
            }
            catch (ArgumentException argEx)
            {
                return BadRequest(new { message = argEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
            }
        }
    }
}
