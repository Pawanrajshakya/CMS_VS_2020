using System;
using Service_Layer.Services;


namespace Service_Layer.Interface
{
    public interface IServiceManager
    {
        IBusinessService Business { get; }
        IRoleService Role {get;}
    }


}