using System;
using System.Collections.Generic;
using System.Linq;
using AppFullStackDemo.Domain.Commands.Manufacturer;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Queries;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Domain.Results.Manufacturer;
using AppFullStackDemo.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace AppFullStackDemo.Infra.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly AppFullStackDemoContext _context;

        public ManufacturerRepository(AppFullStackDemoContext context)
        {
            _context = context;
        }

        public void Create(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
        }

        public void Update(Manufacturer manufacturer)
        {
            _context.Entry(manufacturer).State = EntityState.Modified;
        }

        public Manufacturer GetById(Guid id)
        {
            return _context
                .Manufacturers
                .FirstOrDefault(x => x.Id == id);
        }

        public Manufacturer GetByDescription(string description)
        {
            return _context
                .Manufacturers
                .FirstOrDefault(x => x.Description == description);
        }

        public IEnumerable<GetManufacturerResult> GetManufacturers()
        {
            var data = _context.Manufacturers
               .Where(ManufacturerQueries.GetAll())
               .OrderBy(x => x.Description)
               .ToList();

            if (data == null)
                return null;

            return data.Select(reg => new GetManufacturerResult
            {
                Id = reg.Id.ToString(),
                Description = reg.Description
            });
        }

        public GetManufacturerResult GetManufacturer(Guid id)
        {
            var data = _context.Manufacturers
               .Where(ManufacturerQueries.GetById(id))
               .FirstOrDefault();


            if (data == null)
                return null;

            return new GetManufacturerResult
            {
                Id = data.Id.ToString(),
                Description = data.Description
            };
        }
    }
}