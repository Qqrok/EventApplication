using ApiLayer.DTOs;
using AutoMapper;
using DataLayer.Models;

namespace ApiLayer.MappingProfiles
{
    public class LocationMappingProfile : Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<Location, LocationDto>().ReverseMap();
        }
    }
}
