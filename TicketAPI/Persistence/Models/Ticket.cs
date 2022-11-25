using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketAPI.Persistence.Models.DataSources;

namespace TicketAPI.Persistence.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PriorityId { get; set; }
        public Priority Priority { get; set; }
        public Guid ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
        public Guid TypeId { get; set; }
        public TicketType Type { get; set; }
        public Guid StatusId { get; set; }
        public TicketStatus Status { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}