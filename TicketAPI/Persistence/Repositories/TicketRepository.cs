using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using TicketAPI.Persistence.Database;
using TicketAPI.Persistence.Models;
using TicketAPI.Persistence.Models.DataSources;

namespace TicketAPI.Persistence.Repositories
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        private readonly TicketContext _ticketContext;

        public TicketRepository(TicketContext ticketContext) : base(ticketContext)
        {
            _ticketContext = ticketContext;
        }

        public override IQueryable<Ticket> GetAll()
        {
            return _ticketContext.Tickets.AsQueryable();
        }

        public override Ticket FirstOrDefault(Expression<Func<Ticket, bool>> expression)
        {
            return _ticketContext.Tickets.FirstOrDefault(expression);
        }

        public override void Update(Ticket ticket)
        {
            var exTicket = _ticketContext.Tickets.FirstOrDefault(o => o.Id == ticket.Id);
            if (exTicket != null)
            {
                exTicket.Status = ticket.Status;
                exTicket.Priority = ticket.Priority;
                exTicket.ServiceType = ticket.ServiceType;
                exTicket.Name = ticket.Name;
                exTicket.Type = ticket.Type;
            }
            _ticketContext.SaveChanges();
        }
        //public Ticket GetById(Guid id)
        //{
        //    return _ticketList.FirstOrDefault(o => o.Id == id);
        //}
    }
}