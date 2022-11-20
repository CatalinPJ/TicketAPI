using Microsoft.EntityFrameworkCore;
using TicketAPI.Persistence.Models;

namespace TicketAPI.Persistence.Database
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}