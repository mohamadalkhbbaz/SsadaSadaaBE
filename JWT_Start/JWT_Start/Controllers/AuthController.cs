using JWT_Start.Dtos;
using JWT_Start.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Start.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrInputDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisrUser(dto);

            if (!result.IsAuthentecated)
                return BadRequest(result.Message);

            return Ok(new { token = result.Token, expiryDate = result.ExpireOn });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginInputDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetToken(dto);

            if (!result.IsAuthentecated)
                return BadRequest(result.Message);

            return Ok(new { token = result.Token, expiryDate = result.ExpireOn });
        }
    }
}
