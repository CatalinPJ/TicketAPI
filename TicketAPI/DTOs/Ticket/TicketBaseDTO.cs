using System.ComponentModel.DataAnnotations;

namespace TicketAPI.DTOs.Ticket
{
    public class TicketBaseDTO
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public Guid PriorityId { get; set; }
        [Required]
        public Guid ServiceTypeId { get; set; }
        [Required]
        public Guid TypeId { get; set; }
        [Required]
        public Guid StatusId { get; set; }
        public string Description { get; set; }
    }
}
