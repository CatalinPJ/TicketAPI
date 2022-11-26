using TicketAPI.DTOs.Ticket;
using TicketAPI.Models;

namespace TicketAPI.Services.Contracts
{
    public interface ITicketService
    {
        ValidationResult<IList<ViewTicketDTO>> GetAll(Guid id);
        Task<ValidationResult<ViewTicketDTO>> GetById(Guid id);
        Task<ValidationResult<string>> Create(AddTicketDTO ticket);
        Task<ValidationResult<string>> Update(EditTicketDTO ticket);
        Task<ValidationResult<string>> Close(Guid id);
        TicketDataSources GetDatasources();
    }
}