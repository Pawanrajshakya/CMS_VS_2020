using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;

namespace Persistence_Layer.Repository
{
    public class TransactionTypeRepository : Repository<TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}