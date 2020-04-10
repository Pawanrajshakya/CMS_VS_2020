using AutoMapper;
using Service_Layer.Dtos;

namespace Service_Layer.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //User
            CreateMap<Persistence_Layer.Models.User, UserDto>().ForMember(x => x.UserRole, opt => opt.Ignore());
            CreateMap<UserDto, Persistence_Layer.Models.User>().ForMember(x => x.UserRole, opt => opt.Ignore()); ;
            
            //Client
            CreateMap<Persistence_Layer.Models.Client, ClientDto>();
            CreateMap<ClientDto, Persistence_Layer.Models.Client>()
                .ForMember(x => x.Business, opt => opt.Ignore())
                .ForMember(x => x.Accounts, opt => opt.Ignore());
            
            //Role
            CreateMap<Persistence_Layer.Models.Role, Service_Layer.Dtos.RoleDto>();
            CreateMap<Service_Layer.Dtos.RoleDto, Persistence_Layer.Models.Role>();

            //Group
            CreateMap<Persistence_Layer.Models.Group, Service_Layer.Dtos.GroupDto>();
            CreateMap<Service_Layer.Dtos.GroupDto, Persistence_Layer.Models.Group>();

            //Relationship
            CreateMap<Persistence_Layer.Models.Relationship, Service_Layer.Dtos.RelationshipDto>();
            CreateMap<Service_Layer.Dtos.RelationshipDto, Persistence_Layer.Models.Relationship>();
            
            //Business
            CreateMap<Persistence_Layer.Models.Business, Service_Layer.Dtos.BusinessDto>();
            CreateMap<Service_Layer.Dtos.BusinessDto, Persistence_Layer.Models.Business>();
            
            //Account
            CreateMap<Persistence_Layer.Models.Account, Service_Layer.Dtos.AccountDto>();
            CreateMap<Service_Layer.Dtos.AccountDto, Persistence_Layer.Models.Account>()
            .ForMember(x => x.Client, opt => opt.Ignore())
            .ForMember(x => x.AccountType, opt => opt.Ignore())
            .ForMember(x => x.Relationship, opt => opt.Ignore())
            .ForMember(x => x.Transactions, opt => opt.Ignore());
            
            //AccountType
            CreateMap<Persistence_Layer.Models.AccountType, Service_Layer.Dtos.AccountTypeDto>();
            CreateMap<Service_Layer.Dtos.AccountTypeDto, Persistence_Layer.Models.AccountType>();

            //Transaction
            CreateMap<Persistence_Layer.Models.Transaction, Service_Layer.Dtos.TransactionDto>();
            CreateMap<Service_Layer.Dtos.TransactionDto, Persistence_Layer.Models.Transaction>()
            .ForMember(x => x.Account, opt => opt.Ignore())
            .ForMember(x => x.TransactionType, opt => opt.Ignore());
            
            //TransactionType
            CreateMap<Persistence_Layer.Models.TransactionType, Service_Layer.Dtos.TransactionTypeDto>();
            CreateMap<Service_Layer.Dtos.TransactionTypeDto, Persistence_Layer.Models.TransactionType>()
            .ForMember(x => x.Account, opt => opt.Ignore());
        }
    }
}