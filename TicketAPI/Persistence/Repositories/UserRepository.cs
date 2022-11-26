using TicketAPI.Persistence.Database;
using TicketAPI.Persistence.Models;

namespace TicketAPI.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly TicketContext _ticketContext;

        public UserRepository(TicketContext ticketContext) : base(ticketContext)
        {
            _ticketContext = ticketContext;
        }
    }
}