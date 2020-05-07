using System;
using System.Collections.Generic;
using System.Linq;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Queries;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Domain.Results.Equipment;
using AppFullStackDemo.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace AppFullStackDemo.Infra.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly
         AppFullStackDemoContext _context;

        public EquipmentRepository(AppFullStackDemoContext context)

        {
            _context = context;
        }

        public void Create(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
        }

        public void Update(Equipment equipment)
        {
            _context.Entry(equipment).State = EntityState.Modified;
        }

        public Equipment GetById(Guid id)
        {
            return _context
                .Equipments
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GetEquipmentResultResumed> GetEquipments()
        {
            var data = _context.Equipments
               .Where(EquipmentQueries.GetAll())
               .Include(p => p.DeviceModel.Manufacturer)
               .Include(p => p.User)
               .OrderBy(x => x.ApiLevelDesc)
               .ToList();

            if (data == null)
                return null;

            return data.Select(reg => new GetEquipmentResultResumed
            {
                Id = reg.Id.ToString(),
                PhoneNumber = reg.PhoneNumber,
                ApiLevel = reg.ApiLevel,
                ApiLevelDesc = reg.ApiLevelDesc,
                SerialNumber = reg.SerialNumber,
                SystemName = reg.SystemName,
                SystemVersion = reg.SystemVersion,
                DeviceModel = reg.DeviceModel.Manufacturer.Description + " " + reg.DeviceModel.Description,
                User = reg.User.Name.ToString()
            });
        }

        public GetEquipmentResult GetEquipment(Guid id)
        {
            var data = _context.Equipments
               .Where(EquipmentQueries.GetById(id))
               .Include(p => p.DeviceModel.Manufacturer)
               .Include(p => p.User)
               .FirstOrDefault();


            if (data == null)
                return null;

            return new GetEquipmentResult
            {
                Id = data.Id.ToString(),
                AndroidId = data.AndroidId,
                Imei1 = data.Imei1,
                Imei2 = data.Imei2,
                PhoneNumber = data.PhoneNumber,
                MacAddress = data.MacAddress,
                ApiLevel = data.ApiLevel,
                ApiLevelDesc = data.ApiLevelDesc,
                SerialNumber = data.SerialNumber,
                SystemName = data.SystemName,
                SystemVersion = data.SystemVersion,
                DeviceModelId = data.DeviceModel.Id,
                DeviceModel = data.DeviceModel.Manufacturer.Description + " " + data.DeviceModel.Description,
                UserId = data.User.Id,
                User = data.User.Name.ToString()
            };
        }

        public IEnumerable<GetEquipmentResultResumed> GetEquipmentsByUser(Guid UserId)
        {
            var data = _context.Equipments
               .Where(EquipmentQueries.GetByUser(UserId))
               .Include(p => p.DeviceModel.Manufacturer)
               .Include(p => p.User)
               .OrderBy(x => x.ApiLevelDesc)
               .ToList();

            if (data == null)
                return null;

            return data.Select(reg => new GetEquipmentResultResumed
            {
                Id = reg.Id.ToString(),
                PhoneNumber = reg.PhoneNumber,
                ApiLevel = reg.ApiLevel,
                ApiLevelDesc = reg.ApiLevelDesc,
                SerialNumber = reg.SerialNumber,
                SystemName = reg.SystemName,
                SystemVersion = reg.SystemVersion,
                DeviceModel = reg.DeviceModel.Manufacturer.Description + " " + reg.DeviceModel.Description,
                User = reg.User.Name.ToString()
            });
        }
    }
}