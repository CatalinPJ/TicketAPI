using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TicketAPI.DTOs.User;
using TicketAPI.Models;
using TicketAPI.Persistence.Models;
using TicketAPI.Persistence.Repositories;
using TicketAPI.Services.Contracts;

namespace TicketAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<ValidationResult<string>> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var user = await _userRepository.FirstOrDefaultAsync(o => o.Username == registerUserDTO.Username);
            if (user is not null)
            {
                return new ValidationResult<string> { IsSuccess = false, ErrorDetails = new ErrorDetails { Message = "An user with the same name already exists", StatusCode = StatusCodes.Status400BadRequest } };
            }

            user = GetRegisteredUser(registerUserDTO);
            await _userRepository.CreateAsync(user);
            return new ValidationResult<string> { IsSuccess = true, Result = "User added successfully" };
        }

        public async Task<ValidationResult<UserDTO>> Login(LoginUserDTO loginUserDTO)
        {
            var user = await _userRepository.FirstOrDefaultAsync(o => o.Username == loginUserDTO.Username);

            if (user is null)
            {
                return new ValidationResult<UserDTO>
                {
                    IsSuccess = false,
                    ErrorDetails = new ErrorDetails { Message = "User doesn't exist", StatusCode = StatusCodes.Status400BadRequest }
                };
            }

            if (!VerifyPasswordHash(loginUserDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ValidationResult<UserDTO>
                {
                    IsSuccess = false,
                    ErrorDetails = new ErrorDetails { Message = "Wrong password", StatusCode = StatusCodes.Status400BadRequest }
                };
            }
            string token = CreateToken(user);

            return new ValidationResult<UserDTO> { IsSuccess = true, Result = new UserDTO { Token = token, Username = user.Username, Id = user.Id} };
        }

        private User GetRegisteredUser(RegisterUserDTO registerUserDTO)
        {
            var user = new User
            {
                Username = registerUserDTO.Username
            };

            using (var hmac = new HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(registerUserDTO.Password));
            }
            return user;
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
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
               _configuration.GetSection("Authorization").GetValue("Secret", string.Empty)));

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
