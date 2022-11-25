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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketStatus>().HasData(
                new TicketStatus { Id = Guid.Parse("7DBE8793-8E32-42A6-B4D1-255130A18334"), Name = "Opened" },
                new TicketStatus { Id = Guid.Parse("230BCE23-DA6F-472B-8868-7BC2F3DDF893"), Name = "Closed" }
                );

            modelBuilder.Entity<Priority>().HasData(
                new Priority { Id = Guid.Parse("45433cc3-6066-4f90-99c0-9bb3894a7a41"), Name = "Low" },
                new Priority { Id = Guid.Parse("1c8258fe-8ee6-4fa8-979b-2358fa9a6430"), Name = "Medium" },
                new Priority { Id = Guid.Parse("4b583b65-cac0-450f-9fc1-4cf136910e6d"), Name = "High" }
                );

            modelBuilder.Entity<ServiceType>().HasData(
               new ServiceType { Id = Guid.Parse("01cc3f5a-2982-4bca-a15e-6deb499856e4"), Name = "VPN" },
               new ServiceType { Id = Guid.Parse("829d26f7-da0c-4796-b32c-267206914016"), Name = "Email" }
               );

            modelBuilder.Entity<TicketType>().HasData(
               new TicketType { Id = Guid.Parse("fba1e732-4b08-4fdb-b630-63f5b203745e"), Name = "T1" },
               new TicketType { Id = Guid.Parse("2e7db44b-ffb1-4c8f-815d-4cb4ebeb90ec"), Name = "T2" }
               );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
    }
}