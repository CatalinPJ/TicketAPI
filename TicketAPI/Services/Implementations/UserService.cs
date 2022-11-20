using System.Security.Cryptography;
using TicketAPI.DTOs.User;
using TicketAPI.Persistence.Models;
using TicketAPI.Services.Contracts;

namespace TicketAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        public User RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var user = GetRegisteredUser(registerUserDTO);
            return user;
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
    }
}
