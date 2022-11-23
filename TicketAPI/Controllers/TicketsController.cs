using Microsoft.AspNetCore.Mvc;
using TicketAPI.Persistence.Models;
using TicketAPI.Services.Contracts;

namespace TicketAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {

        private readonly ILogger<TicketsController> _logger;
        private readonly ITicketService _ticketService;

        public TicketsController(ILogger<TicketsController> logger, ITicketService ticketService)
        {
            _logger = logger;
            _ticketService = ticketService;
        }

        [HttpGet]
        //[Authorize]
        public ActionResult<Ticket> GetAll()
        {
            return Ok(_ticketService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize]
        public ActionResult<Ticket> GetById(Guid id)
        {
            return Ok(_ticketService.GetById(id));
        }
    }
}