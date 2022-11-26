namespace TicketAPI.DTOs.Ticket
{
    public class ViewTicketDTO: TicketBaseDTO
    {
        public Guid Id { get; set; }
        public string Priority { get; set; }
        public string ServiceType { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Customer { get; set; }
    }
}