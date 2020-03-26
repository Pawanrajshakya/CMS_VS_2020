using System.Threading.Tasks;
using Persistence_Layer.Models;

namespace Persistence_Layer.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}