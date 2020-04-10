using System;
using Service_Layer.Services;


namespace Service_Layer.Interface
{
    public interface IServiceManager
    {
        IBusinessService Business { get; }
        IRoleService Role { get; }
        IAccountTypeService AccountType { get; }
        IAccountService Account { get; set; }
        IClientService Client { get; set; }
        IGroupService Group { get; set; }
        IRelationshipService Relationship { get; set; }
        ITransactionTypeService TransactionType { get; set; }
        ITransactionService Transaction { get; set; }
        IUserService User { get; set; }
    }


}