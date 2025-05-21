using Microsoft.AspNetCore.Mvc;
using SyncListMicroSIP.Dtos;
using SyncListMicroSIP.Models;
using SyncListMicroSIP.Service;

namespace SyncListMicroSIP.Controllers
{
    [ApiController]
    [Route("v1/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("{id}")]
        public async Task<IActionResult> auth([FromRoute] string id, [FromServices] TokenService tokenService) 
        {
            if(id != "526")
            {
                return StatusCode(401, new ResponseDto<string>("Não autorizado!"));
            }

            var token = tokenService.GenerateToken(id);

            return Ok(new ResponseDto<string>(token));
        }
    }
}
