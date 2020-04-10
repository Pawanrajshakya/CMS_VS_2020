using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public class ServiceManager : IServiceManager
    {
        public ServiceManager(
            IBusinessService business, 
            IRoleService role, 
            IUserService user, 
            IAccountTypeService accountType,
            IGroupService group,
            IAccountService account,
            IClientService client,
            IRelationshipService relationship)
        {
            this.Business = business;
            this.Role = role;
            this.User = user;
            this.AccountType = accountType;
            this.Group = group;
            this.Account = account;
            this.Client = client;
            this.Relationship = relationship;
        }

        public IBusinessService Business { get; private set; }
        public IRoleService Role { get; private set; }
        public IAccountTypeService AccountType { get; private set; }
        public IAccountService Account { get; set; }
        public IClientService Client { get; set; }  
        public IGroupService Group { get; set; }
        public IRelationshipService Relationship { get; set; }
        public ITransactionTypeService TransactionType { get; set; }
        public ITransactionService Transaction { get; set; }
        public IUserService User { get; set; }
    }
}