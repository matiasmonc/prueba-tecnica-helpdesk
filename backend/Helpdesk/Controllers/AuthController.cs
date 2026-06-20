using Helpdesk.Business.DTOs;
using Helpdesk.Business.Interfaces;
using Helpdesk.Business.Services;
using Helpdesk.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid Model");
            }

            await _authService.CreateUserAsync(createUserDTO);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid Model");
            }

            var (user, token) = await _authService.Login(loginDTO);

            return Ok(new { User = user, Token = token });
        }
    }
}
