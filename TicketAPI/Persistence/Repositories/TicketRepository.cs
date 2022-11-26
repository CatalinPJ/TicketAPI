using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketAPI.DTOs.Ticket;
using TicketAPI.Persistence.Database;
using TicketAPI.Persistence.Models;

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

        public TicketDataSources GetDatasources()
        {
            return new TicketDataSources
            {
                Priorities = TicketContext.Priorities.AsQueryable(),
                TicketTypes = TicketContext.TicketTypes.AsQueryable(),
                ServiceTypes = TicketContext.ServiceTypes.AsQueryable(),
                TicketStatuses = TicketContext.TicketStatuses.AsQueryable()
            };
        }

        public async Task Close(Guid id)
        {
            var ticket = await _ticketContext.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            ticket.StatusId = (await TicketContext.TicketStatuses.FirstOrDefaultAsync(t => t.Name == "Closed")).Id;
            ticket.ClosedOn = DateTimeOffset.Now;

            UpdateAsync(ticket);
        }
    }
}