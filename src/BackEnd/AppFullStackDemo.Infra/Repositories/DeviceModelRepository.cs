using System;
using System.Collections.Generic;
using System.Linq;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Queries;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace AppFullStackDemo.Infra.Repositories
{
    public class DeviceModelRepository : IDeviceModelRepository
    {
        private readonly AppFullStackDemoContext _context;

        public DeviceModelRepository(AppFullStackDemoContext context)
        {
            _context = context;
        }

        public void Create(DeviceModel deviceModel)
        {
            _context.DeviceModels.Add(deviceModel);
        }

        public void Update(DeviceModel deviceModel)
        {
            _context.Entry(deviceModel).State = EntityState.Modified;
        }

        public DeviceModel GetById(Guid id)
        {
            return _context
                .DeviceModels
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<DeviceModel> GetAll()
        {
            return _context.DeviceModels
               .Where(DeviceModelQueries.GetAll())
               .OrderBy(x => x.Description
               );
        }
    }
}