using ApiLayer.DTOs;
using DataLayer.Models;
using AutoMapper;


namespace ApiLayer.MappingProfiles
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
        }
    }
}
