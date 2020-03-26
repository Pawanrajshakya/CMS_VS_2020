using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;

namespace Persistence_Layer.Repository
{
    public class BusinessRepository : Repository<Business>, IBusinessRepository
    {
        public BusinessRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}