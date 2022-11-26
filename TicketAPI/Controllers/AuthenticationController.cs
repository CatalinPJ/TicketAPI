using Microsoft.AspNetCore.Mvc;
using TicketAPI.DTOs.User;
using TicketAPI.Persistence.Models;
using TicketAPI.Services.Contracts;

namespace TicketAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterUserDTO registerUserDTO)
        {
            var registerResult = await _userService.RegisterUser(registerUserDTO);
            if (registerResult.IsSuccess)
            {
                return Ok(registerResult.Result);
            }
            return BadRequest(registerResult.ErrorDetails.Message);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginUserDTO loginUserDTO)
        {
            var loginResult = await _userService.Login(loginUserDTO);
            if (loginResult.IsSuccess)
            {
                return Ok(loginResult.Result);
            }
            return BadRequest(loginResult.ErrorDetails.Message);
        }
    }
}