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

        [HttpPost]
        //[Authorize]
        public ActionResult<Ticket> Create(Ticket ticket)
        {
            _ticketService.Create(ticket);
            return Ok(ticket);
        }

        [HttpPut]
        //[Authorize]
        public ActionResult<Ticket> Update(Ticket ticket)
        {
            _ticketService.Update(ticket);
            return Ok(ticket);
        }

        [HttpGet]
        [Route("datasources")]
        //[Authorize]
        public ActionResult<Ticket> GetDatasources()
        {
            return Ok(_ticketService.GetDatasources());
        }
    }
}