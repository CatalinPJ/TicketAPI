using Microsoft.EntityFrameworkCore;
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
            return _ticketContext.Tickets.Include(o => o.ServiceType).Include(o => o.Status).Include(o => o.Priority).Include(o => o.Type).FirstOrDefault(expression);
        }

        public object GetDatasources()
        {
            return new
            {
                Priorities = TicketContext.Priorities.AsQueryable(),
                TicketTypes = TicketContext.TicketTypes.AsQueryable(),
                ServiceTypes = TicketContext.ServiceTypes.AsQueryable(),
                TicketStatuses = TicketContext.TicketStatuses.AsQueryable(),
            };
        }

        public void Close(Guid id)
        {
            var ticket = _ticketContext.Tickets.FirstOrDefault(t => t.Id == id);
            ticket.StatusId = TicketContext.TicketStatuses.FirstOrDefault(t => t.Name == "Closed").Id;
            Update(ticket);
        }
    }
}