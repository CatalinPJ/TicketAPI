using TicketAPI.Persistence.Models;

namespace TicketAPI.Persistence.Repositories
{
    public interface ITicketRepository
    {
        IList<Ticket> GetAll ();
        Ticket GetById(Guid id);
    }
}
