namespace TicketAPI.DTOs.Ticket
{
    public class ViewTicketDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PriorityId { get; set; }
        public Guid ServiceTypeId { get; set; }
        public Guid TypeId { get; set; }
        public Guid StatusId { get; set; }

        public string Priority { get; set; }
        public string ServiceType { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}