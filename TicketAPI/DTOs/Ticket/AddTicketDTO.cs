namespace TicketAPI.DTOs.Ticket
{
    public class AddTicketDTO
    {
        public string Name { get; set; }
        public Guid PriorityId { get; set; }
        public Guid ServiceTypeId { get; set; }
        public Guid TypeId { get; set; }
        public Guid StatusId { get; set; }
    }
}