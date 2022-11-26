using TicketAPI.Persistence.Models;
using TicketAPI.Persistence.Repositories;
using TicketAPI.Services.Contracts;
using TicketAPI.Persistence.Models.DataSources;
using TicketAPI.DTOs.Ticket;
using System.Net.Sockets;
using TicketAPI.Persistence.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
                cfg.CreateMap<EditTicketDTO, Ticket>();
                cfg.CreateMap<Ticket, ViewTicketDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name))
                .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.ServiceType.Name));
            });
            _mapper = new Mapper(config);
        }

        public IList<ViewTicketDTO> GetAll()
        {
            var lst = _ticketRepository.GetAll().Include(o => o.Priority).Include(o => o.Type).Include(o => o.ServiceType).Include(o => o.Status);
            return _mapper.Map<IList<ViewTicketDTO>>(lst);
        }

        public Ticket GetById(Guid id)
        {
            var ticket = _ticketRepository.FirstOrDefault(o => o.Id == id);
            return ticket;
        }

        public object GetDatasources()
        {
            return _ticketRepository.GetDatasources();
        }

        public void Create(AddTicketDTO addTicketDTO)
        {
            var ticket = _mapper.Map<Ticket>(addTicketDTO);
            ticket.CreatedOn = DateTimeOffset.Now;
            _ticketRepository.Create(ticket);
        }


        public void Update(EditTicketDTO editTicketDTO)
        {
            var exTicket = _mapper.Map<Ticket>(editTicketDTO);
            _ticketRepository.Update(exTicket);
        }

        public void Close(Guid id)
        {
            _ticketRepository.Close(id);
        }
    }
}