using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicketAPI.DTOs.Ticket;
using TicketAPI.Services.Contracts;

namespace TicketAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IList<ViewTicketDTO>> GetAll()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var getResult = _ticketService.GetAll(Guid.Parse(userId));
            if (getResult.IsSuccess)
            {
                return Ok(getResult.Result);
            }
            return BadRequest(getResult.ErrorDetails.Message);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<ActionResult<ViewTicketDTO>> GetById(Guid id)
        {
            var createResult = await _ticketService.GetById(id);
            if (createResult.IsSuccess)
            {
                return Ok(createResult.Result);
            }
            return BadRequest(createResult.ErrorDetails.Message);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<string>> Create(AddTicketDTO addTicketDTO)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            addTicketDTO.UserId = Guid.Parse(userId);
            var createResult = await _ticketService.Create(addTicketDTO);
            if (createResult.IsSuccess)
            {
                return Ok(JsonConvert.SerializeObject(createResult.Result));
            }
            return BadRequest(createResult.ErrorDetails.Message);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<string>> Update(EditTicketDTO editTicketDTO)
        {
            var updateResult = await _ticketService.Update(editTicketDTO);
            if (updateResult.IsSuccess)
            {
                return Ok(JsonConvert.SerializeObject(updateResult.Result));
            }
            return BadRequest(updateResult.ErrorDetails.Message);
        }

        [HttpPut]
        [Route("close")]
        [Authorize]
        public async Task<ActionResult<string>> Close(Guid id)
        {
            var closeResult = await _ticketService.Close(id);
            if (closeResult.IsSuccess)
            {
                return Ok(JsonConvert.SerializeObject(closeResult.Result));
            }
            return BadRequest(closeResult.ErrorDetails.Message);
        }

        [HttpGet]
        [Route("datasources")]
        public ActionResult<TicketDataSources> GetDatasources()
        {
            return Ok(_ticketService.GetDatasources());
        }
    }
}