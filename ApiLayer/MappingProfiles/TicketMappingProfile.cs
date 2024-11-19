using ApiLayer.DTOs;
using AutoMapper;
using DataLayer.Models;

namespace ApiLayer.MappingProfiles
{
    public class TicketMappingProfile : Profile
    {
        public TicketMappingProfile()
        {
            CreateMap<Ticket, TicketDto>().ReverseMap();
        }
    }
}
