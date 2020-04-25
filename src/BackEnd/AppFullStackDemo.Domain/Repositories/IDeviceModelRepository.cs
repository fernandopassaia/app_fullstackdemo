using System;
using System.Collections.Generic;
using AppFullStackDemo.Domain.Entities;

namespace AppFullStackDemo.Domain.Repositories
{
    public interface IDeviceModelRepository
    {
        void Create(DeviceModel deviceModel);
        void Update(DeviceModel deviceModel);
        DeviceModel GetById(Guid id);
        IEnumerable<DeviceModel> GetAll();
        //GetResumed
    }
}