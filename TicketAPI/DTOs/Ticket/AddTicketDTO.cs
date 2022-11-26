using System.ComponentModel.DataAnnotations;

namespace TicketAPI.DTOs.Ticket
{
    public class AddTicketDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid PriorityId { get; set; }
        [Required]
        public Guid ServiceTypeId { get; set; }
        [Required]
        public Guid TypeId { get; set; }
        [Required]
        public Guid StatusId { get; set; }
    }
}