using System;
using System.Collections.Generic;
using AppFullStackDemo.Domain.Entities;

namespace AppFullStackDemo.Domain.Repositories
{
    public interface IManufacturerRepository
    {
        void Create(Manufacturer manufacturer);
        void Update(Manufacturer manufacturer);
        Manufacturer GetById(Guid id);
        IEnumerable<Manufacturer> GetAll();
        //GetResumed
    }
}