using TicketAPI.Persistence.Models;
using TicketAPI.Persistence.Repositories;
using TicketAPI.Services.Contracts;

namespace TicketAPI.Services.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _ticketRepository.GetAll();
        }

        public Ticket GetById(Guid id)
        {
            return _ticketRepository.FirstOrDefault(o=>o.Id == id);
        }
    }
}