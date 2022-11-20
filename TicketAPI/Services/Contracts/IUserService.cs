using TicketAPI.DTOs.User;
using TicketAPI.Persistence.Models;

namespace TicketAPI.Services.Contracts
{
    public interface IUserService
    {
        User RegisterUser(RegisterUserDTO registerUserDTO);
    }
}
