using System;

namespace Persistence_Layer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Account { get; }
        IAccountTypeRepository AccountType { get; }
        IBusinessRepository Business { get; }
        IClientRepository Client { get; }
        IGroupRepository Group { get; }
        IRelationshipRepository Relationship { get; }
        IRoleRepository Role { get; }
        ITransactionRepository Transaction { get; }
        ITransactionTypeRepository TransactionType { get; }
        IUserRepository User { get; }
        int Complete();
    }
}