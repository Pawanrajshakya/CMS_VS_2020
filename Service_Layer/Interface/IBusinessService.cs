using System.Collections.Generic;
using System.Threading.Tasks;
using Service_Layer.Dtos;

namespace Service_Layer.Interface
{
    public interface IBusinessService
    {
        Task<bool> Add(BusinessDto businessDto);

        Task<BusinessDto> Get(int id);

        Task<IEnumerable<BusinessDto>> GetAll();

        Task<bool> Remove(int id);

        Task<bool> SoftDelete(int id);

        Task<bool> Update(int id, BusinessDto businessDto);

    }
}