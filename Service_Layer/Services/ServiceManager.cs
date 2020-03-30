using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public class ServiceManager : IServiceManager
    {
        public ServiceManager(IBusinessService business)
        {
            this.Business = business;
        }

        public IBusinessService Business { get; private set; }
    }
}