using TicketAPI.DTOs.Ticket;
using TicketAPI.Persistence.Models;

namespace TicketAPI.Services.Contracts
{
    public interface ITicketService
    {
        IList<ViewTicketDTO> GetAll();
        Ticket GetById(Guid id);
        void Create(AddTicketDTO ticket);
        void Update(EditTicketDTO ticket);
        void Close(Guid id);
        object GetDatasources();
    }
}
