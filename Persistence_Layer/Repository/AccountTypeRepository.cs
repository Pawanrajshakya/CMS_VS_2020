using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;

namespace Persistence_Layer.Repository
{
    public class AccountTypeRepository : Repository<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}