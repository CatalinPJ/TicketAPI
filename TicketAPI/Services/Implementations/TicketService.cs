using TicketAPI.Persistence.Models;
using TicketAPI.Persistence.Repositories;
using TicketAPI.Services.Contracts;
using TicketAPI.Persistence.Models.DataSources;

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
            var ticket = _ticketRepository.FirstOrDefault(o => o.Id == id);

            return ticket;
        }

        public object GetDatasources()
        {
            return new
            {
                Priorities = new List<Priority> { new Priority { Name = "High" }, new Priority { Name = "Low" } },
                TicketTypes = new List<TicketType> { new TicketType { Name = "VPN" }, new TicketType { Name = "Applications" } },
                ServiceTypes = new List<ServiceType> { new ServiceType { Name = "SV2" }, new ServiceType { Name = "SV5" } },
                TicketStatuses = new List<TicketStatus> { new TicketStatus { Name = "Opened" }, new TicketStatus { Name = "Closed" } },
            };
        }

        public void Create(Ticket ticket)
        {
            _ticketRepository.Create(ticket);
        }


        public void Update(Ticket ticket)
        {
            _ticketRepository.Update(ticket);
        }
    }
}