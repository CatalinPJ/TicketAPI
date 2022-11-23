using TicketAPI.Persistence.Models;

namespace TicketAPI.Persistence.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IList<Ticket> _ticketList = new List<Ticket>
        {
            new Ticket { Id = Guid.Parse("25cf10cb-033b-463c-8ff5-0909311feb89"), Name = "Ticket1" },

            new Ticket { Id = Guid.Parse("af2fbc62-8200-43da-a3b6-890cf173fc15"), Name = "Ticket2" }
        };
        public IList<Ticket> GetAll()
        {
            return _ticketList;
        }

        public Ticket GetById(Guid id)
        {
            return _ticketList.FirstOrDefault(o => o.Id == id);
        }
    }
}