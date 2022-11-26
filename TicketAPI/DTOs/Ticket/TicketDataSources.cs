using TicketAPI.Persistence.Models.DataSources;

namespace TicketAPI.DTOs.Ticket
{
    public class TicketDataSources
    {

        public IQueryable<Priority> Priorities { get; set; }
        public IQueryable<TicketType> TicketTypes { get; set; }
        public IQueryable<ServiceType> ServiceTypes { get; set; }
        public IQueryable<TicketStatus> TicketStatuses { get; set; }
    }
}