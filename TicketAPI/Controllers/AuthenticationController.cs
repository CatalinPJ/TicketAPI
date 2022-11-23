using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using TicketAPI.DTOs.User;
using TicketAPI.Persistence.Models;
using TicketAPI.Services.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace TicketAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {

        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserService _userService;

        private static User nuser = new();

        public AuthenticationController(ILogger<AuthenticationController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(RegisterUserDTO registerUserDTO)
        {
            var user = _userService.RegisterUser(registerUserDTO);
            nuser = user;
            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(LoginUserDTO loginUserDTO)
        {
            if (nuser.Username != loginUserDTO.Username)
            {
                return BadRequest("User not found.");
            }

            if (!VerifyPasswordHash(loginUserDTO.Password, nuser.PasswordHash, nuser.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(nuser);


            return Ok(new { token = token, name = nuser.Username });
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
               "my top secret key"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}