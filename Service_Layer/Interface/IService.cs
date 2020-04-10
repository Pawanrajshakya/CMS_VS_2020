using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service_Layer.Interface
{
    public interface IService<T> where T : class
    {
        Task<bool> Add(T entity);

        Task<T> Get(int id);

        Task<IEnumerable<T>> GetAll();

        Task<bool> Remove(int id);

        Task<bool> SoftDelete(int id);

        Task<bool> Update(int id, T entity);
    }
}