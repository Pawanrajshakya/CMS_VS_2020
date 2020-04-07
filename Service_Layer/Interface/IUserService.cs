using System.Threading.Tasks;
using Persistence_Layer.Models;
using Service_Layer.Dtos;

namespace Service_Layer.Interface
{
    public interface IUserService : IService<UserDto>
    {
        // Task<UserDto> Register(User user, string password);
        Task<UserDto> Login(string username, string password);
    }
}