using TicketAPI.DTOs.Ticket;
using TicketAPI.Persistence.Models;

namespace TicketAPI.Services.Contracts
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAll();
        Ticket GetById(Guid id);
        void Create(AddTicketDTO ticket);
        void Update(EditTicketDTO ticket);
        object GetDatasources();
    }
}
