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
        public Priority Priority { get; set; }
        public ServiceType ServiceType { get; set; }
        public TicketType Type { get; set; }
        public TicketStatus Status { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}