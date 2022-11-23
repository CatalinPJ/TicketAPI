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
        private readonly IList<Ticket> _ticketList;
        public TicketRepository(TicketContext ticketContext) : base(ticketContext)
        {
            _ticketList = new List<Ticket>
            {
                new Ticket {
                    Id = Guid.Parse("25cf10cb-033b-463c-8ff5-0909311feb89"),
                    Name = "Ticket1",
                    Priority = new Priority { Name = "High" },
                    Status = new TicketStatus { Name = "Opened" },
                    ServiceType = new ServiceType { Name = "SV2" },
                    Type = new TicketType { Name = "VPN" }
                },

                new Ticket {
                    Id = Guid.Parse("af2fbc62-8200-43da-a3b6-890cf173fc15"), 
                    Name = "Ticket2",
                    Priority = new Priority { Name = "Low" },
                    Status = new TicketStatus { Name = "Closed" },
                    ServiceType = new ServiceType { Name = "SV5" },
                    Type = new TicketType { Name = "Applications" }}
            };
        }

        public override IQueryable<Ticket> GetAll()
        {
            return _ticketList.AsQueryable();
        }

        public override Ticket FirstOrDefault(Expression<Func<Ticket, bool>> expression)
        {
            return _ticketList.AsQueryable().FirstOrDefault(expression);
        }
        //public Ticket GetById(Guid id)
        //{
        //    return _ticketList.FirstOrDefault(o => o.Id == id);
        //}
    }
}