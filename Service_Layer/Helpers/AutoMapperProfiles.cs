using AutoMapper;

namespace Service_Layer.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Persistence_Layer.Models.User, Service_Layer.Dtos.UserDto>();
            CreateMap<Service_Layer.Dtos.UserDto, Persistence_Layer.Models.User>();
            CreateMap<Persistence_Layer.Models.Role, Service_Layer.Dtos.RoleDto>();
            CreateMap<Service_Layer.Dtos.RoleDto, Persistence_Layer.Models.Role>();
            CreateMap<Persistence_Layer.Models.Business, Service_Layer.Dtos.BusinessDto>();
            CreateMap<Service_Layer.Dtos.BusinessDto, Persistence_Layer.Models.Business>();
        }
    }
}