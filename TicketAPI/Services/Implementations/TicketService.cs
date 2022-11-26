using TicketAPI.Persistence.Models;
using TicketAPI.Persistence.Repositories;
using TicketAPI.Services.Contracts;
using TicketAPI.DTOs.Ticket;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketAPI.Models;

namespace TicketAPI.Services.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddTicketDTO, Ticket>();

                cfg.CreateMap<EditTicketDTO, Ticket>().ForMember(o => o.Customer, act => act.Ignore());

                cfg.CreateMap<Ticket, ViewTicketDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name))
                .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.ServiceType.Name));
            });
            _mapper = new Mapper(config);
        }

        public ValidationResult<IList<ViewTicketDTO>> GetAll(Guid id)
        {
            var tickets = _ticketRepository.GetAll()
                .Include(o => o.Priority)
                .Include(o => o.Type)
                .Include(o => o.ServiceType)
                .Include(o => o.Status)
                .Where(o => o.UserId == id && o.Status.Name != "Closed");
            var ticketsDTO = _mapper.Map<IList<ViewTicketDTO>>(tickets);
            return new ValidationResult<IList<ViewTicketDTO>>
            {
                IsSuccess = true,
                Result = ticketsDTO
            };
        }

        public async Task<ValidationResult<ViewTicketDTO>> GetById(Guid id)
        {
            var ticket = await _ticketRepository.FirstOrDefaultAsync(o => o.Id == id);
            if (ticket == null)
                return new ValidationResult<ViewTicketDTO>
                {
                    ErrorDetails = new ErrorDetails { StatusCode = StatusCodes.Status404NotFound, Message = "Ticket not found" },
                    IsSuccess = true
                };

            var viewTicketDTO = _mapper.Map<ViewTicketDTO>(ticket);
            return new ValidationResult<ViewTicketDTO>
            {
                Result = viewTicketDTO,
                IsSuccess = true
            };
        }

        public async Task<ValidationResult<string>> Create(AddTicketDTO addTicketDTO)
        {
            try
            {
                var ticket = _mapper.Map<Ticket>(addTicketDTO);
                ticket.CreatedOn = DateTimeOffset.Now;
                await _ticketRepository.CreateAsync(ticket);
                return new ValidationResult<string> { IsSuccess = true, Result = "Ticket created" };
            }
            catch (Exception ex)
            {
                return new ValidationResult<string>
                {
                    ErrorDetails = new ErrorDetails { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message },
                };
            }
        }

        public async Task<ValidationResult<string>> Update(EditTicketDTO editTicketDTO)
        {
            try
            {
                var existingTicket = await _ticketRepository.FirstOrDefaultAsync(o => o.Id == editTicketDTO.Id);
                UpdateTicket(existingTicket, editTicketDTO);
                await _ticketRepository.UpdateAsync(existingTicket);
                return new ValidationResult<string> { IsSuccess = true, Result = "Ticket updated" };
            }
            catch (Exception ex)
            {
                return new ValidationResult<string>
                {
                    ErrorDetails = new ErrorDetails { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message },
                };
            }
        }

        public async Task<ValidationResult<string>> Close(Guid id)
        {
            try
            {
                await _ticketRepository.Close(id);
                return new ValidationResult<string> { IsSuccess = true, Result = "Ticket closed" };
            }
            catch (Exception ex)
            {
                return new ValidationResult<string>
                {
                    ErrorDetails = new ErrorDetails { StatusCode = StatusCodes.Status400BadRequest, Message = ex.Message },
                };
            }
        }

        public TicketDataSources GetDatasources()
        {
            return _ticketRepository.GetDatasources();
        }

        private void UpdateTicket(Ticket existingTicket, EditTicketDTO editTicketDTO)
        {
            existingTicket.StatusId = editTicketDTO.StatusId;
            existingTicket.PriorityId = editTicketDTO.PriorityId;
            existingTicket.TypeId = editTicketDTO.TypeId;
            existingTicket.ServiceTypeId = editTicketDTO.ServiceTypeId;
            existingTicket.Subject = editTicketDTO.Subject;
            existingTicket.Description = editTicketDTO.Description;
        }
    }
}