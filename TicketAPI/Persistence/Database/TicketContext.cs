using Microsoft.EntityFrameworkCore;
using TicketAPI.Persistence.Models;
using TicketAPI.Persistence.Models.DataSources;

namespace TicketAPI.Persistence.Database
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
    }
}