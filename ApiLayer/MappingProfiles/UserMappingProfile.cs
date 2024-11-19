using ApiLayer.DTOs;
using AutoMapper;
using DataLayer.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiLayer.MappingProfiles
{
    

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }

}
