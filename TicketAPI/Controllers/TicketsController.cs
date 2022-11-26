using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketAPI.DTOs.Ticket;
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
        [Authorize]
        public ActionResult<IEnumerable<ViewTicketDTO>> GetAll()
        {
            return Ok(_ticketService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public ActionResult<Ticket> GetById(Guid id)
        {
            return Ok(_ticketService.GetById(id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Ticket> Create(AddTicketDTO addTicketDTO)
        {
            _ticketService.Create(addTicketDTO);
            return Ok(addTicketDTO);
        }

        [HttpPut]
        [Authorize]
        public ActionResult<Ticket> Update(EditTicketDTO editTicketDTO)
        {
            _ticketService.Update(editTicketDTO);
            return Ok(editTicketDTO);
        }

        [HttpPut]
        [Route("close")]
        [Authorize]
        public ActionResult<Ticket> Close(Guid id)
        {
            _ticketService.Close(id);
            return Ok();
        }

        [HttpGet]
        [Route("datasources")]
        public ActionResult<Ticket> GetDatasources()
        {
            return Ok(_ticketService.GetDatasources());
        }
    }
}