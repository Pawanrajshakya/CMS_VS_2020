using AutoMapper;
using Persistence_Layer.Models;
using Web_API.Dtos;

namespace Web_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UsersDto>();
            CreateMap<Business, BusinessDto>();
            CreateMap<BusinessDto, Business>();
        }
    }
}