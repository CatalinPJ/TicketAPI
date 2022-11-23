using TicketAPI.Persistence.Models;

namespace TicketAPI.Services.Contracts
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAll();
        Ticket GetById(Guid id);
    }
}
