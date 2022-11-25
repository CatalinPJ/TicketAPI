using TicketAPI.Persistence.Models;
using TicketAPI.Persistence.Repositories;
using TicketAPI.Services.Contracts;
using TicketAPI.Persistence.Models.DataSources;
using TicketAPI.DTOs.Ticket;
using System.Net.Sockets;
using TicketAPI.Persistence.Database;

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
            return _ticketRepository.GetDatasources();
        }

        public void Create(AddTicketDTO addTicketDTO)
        {
            var ticket = new Ticket
            {
                Name = addTicketDTO.Name,
                PriorityId = addTicketDTO.PriorityId,
                ServiceTypeId = addTicketDTO.ServiceTypeId,
                StatusId = addTicketDTO.StatusId,
                TypeId = addTicketDTO.TypeId,
                CreatedOn = DateTimeOffset.Now
            };
            _ticketRepository.Create(ticket);
        }


        public void Update(EditTicketDTO editTicketDTO)
        {
            var exTicket = _ticketRepository.FirstOrDefault(o => o.Id == editTicketDTO.Id);
            if (exTicket != null)
            {
                exTicket.StatusId = editTicketDTO.StatusId;
                exTicket.PriorityId = editTicketDTO.PriorityId;
                exTicket.ServiceTypeId = editTicketDTO.ServiceTypeId;
                exTicket.Name = editTicketDTO.Name;
                exTicket.TypeId = editTicketDTO.TypeId;
            }
            _ticketRepository.Update(exTicket);
        }
    }
}