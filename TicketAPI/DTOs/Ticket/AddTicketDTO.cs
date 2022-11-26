using System.ComponentModel.DataAnnotations;

namespace TicketAPI.DTOs.Ticket
{
    public class AddTicketDTO : TicketBaseDTO
    {
        public string Customer { get; set; }
    }
}