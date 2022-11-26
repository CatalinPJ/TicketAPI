using TicketAPI.DTOs.Ticket;
using TicketAPI.Persistence.Models;

namespace TicketAPI.Persistence.Repositories
{
    public interface ITicketRepository : IRepositoryBase<Ticket>
    {
        Task Close(Guid id);
        TicketDataSources GetDatasources();
    }
}
