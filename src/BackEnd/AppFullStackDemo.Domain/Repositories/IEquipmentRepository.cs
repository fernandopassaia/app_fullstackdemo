using System;
using System.Collections.Generic;
using AppFullStackDemo.Domain.Entities;

namespace AppFullStackDemo.Domain.Repositories
{
    public interface IEquipmentRepository
    {
        void Create(Equipment equipment);
        void Update(Equipment equipment);
        Equipment GetById(Guid id);
        IEnumerable<Equipment> GetAll();
        //GetResumed
    }
}