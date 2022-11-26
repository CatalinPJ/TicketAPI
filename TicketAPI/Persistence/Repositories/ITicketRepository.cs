using TicketAPI.Persistence.Models;

namespace TicketAPI.Persistence.Repositories
{
    public interface ITicketRepository : IRepositoryBase<Ticket>
    {
        void Close(Guid id);
        object GetDatasources();
    }
}
