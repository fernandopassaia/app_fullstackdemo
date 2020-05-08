using System;
using System.Collections.Generic;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Results.Manufacturer;

namespace AppFullStackDemo.Domain.Repositories
{
    public interface IManufacturerRepository
    {
        void Create(Manufacturer manufacturer);
        void Update(Manufacturer manufacturer);
        Manufacturer GetById(Guid id);
        IEnumerable<GetManufacturerResult> GetManufacturers();
        GetManufacturerResult GetManufacturer(Guid id);
    }
}