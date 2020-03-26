using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;

namespace Persistence_Layer.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}