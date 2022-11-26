using TicketAPI.DTOs.User;
using TicketAPI.Models;

namespace TicketAPI.Services.Contracts
{
    public interface IUserService
    {
        Task<ValidationResult<string>> RegisterUser(RegisterUserDTO registerUserDTO);
        Task<ValidationResult<UserDTO>> Login(LoginUserDTO loginUserDTO);
    }
}