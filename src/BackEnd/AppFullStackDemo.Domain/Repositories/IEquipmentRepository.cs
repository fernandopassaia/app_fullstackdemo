using System;
using System.Collections.Generic;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Results.Equipment;

namespace AppFullStackDemo.Domain.Repositories
{
    public interface IEquipmentRepository
    {
        void Create(Equipment equipment);
        void Update(Equipment equipment);
        Equipment GetById(Guid id);
        IEnumerable<GetEquipmentResultResumed> GetEquipments();
        GetEquipmentResult GetEquipment(Guid id);
        IEnumerable<GetEquipmentResultResumed> GetEquipmentsByUser(Guid UserId);
    }
}