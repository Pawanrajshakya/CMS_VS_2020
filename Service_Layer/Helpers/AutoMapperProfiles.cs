using AutoMapper;
using Persistence_Layer.Models;
using Service_Layer.Dtos;

namespace Service_Layer.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UsersDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<Persistence_Layer.Models.Business, BusinessDto>();
            CreateMap<Service_Layer.Dtos.BusinessDto, Persistence_Layer.Models.Business>();
        }
    }
}