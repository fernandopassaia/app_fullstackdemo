using System;
using System.Collections.Generic;
using System.Linq;
using AppFullStackDemo.Domain.Commands.DeviceModel;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Queries;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Domain.Results.DeviceModel;
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

        public GetDeviceModelResult GetDeviceModel(Guid id)
        {
            var data = _context
                .DeviceModels
                .Include(p => p.Manufacturer)
                .FirstOrDefault(x => x.Id == id);

            if (data == null)
                return null;

            return new GetDeviceModelResult
            {
                Id = data.Id.ToString(),
                Description = data.Description,
                Manufacturer = data.Manufacturer.Description,
                ManufacturerId = data.Manufacturer.Id.ToString()
            };
        }

        public IEnumerable<GetDeviceModelResult> GetDeviceModels()
        {
            var data = _context.DeviceModels
               .Where(DeviceModelQueries.GetAll())
               .Include(p => p.Manufacturer)
               .OrderBy(x => x.Description
               );

            if (data == null)
                return null;

            return data.Select(reg => new GetDeviceModelResult
            {
                Id = reg.Id.ToString(),
                Description = reg.Description,
                Manufacturer = reg.Manufacturer.Description,
                ManufacturerId = reg.Manufacturer.Id.ToString()
            });
        }

        public DeviceModel GetById(Guid id)
        {
            return _context
                .DeviceModels
                .FirstOrDefault(x => x.Id == id);
        }
    }
}