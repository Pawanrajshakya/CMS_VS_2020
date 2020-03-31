using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public class ServiceManager : IServiceManager
    {
        public ServiceManager(IBusinessService business, IRoleService role)
        {
            this.Business = business;
            this.Role = role;
        }

        public IBusinessService Business { get; private set; }
        public IRoleService Role { get; private set; }
    }
}