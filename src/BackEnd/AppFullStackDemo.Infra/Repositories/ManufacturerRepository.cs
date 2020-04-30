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

        public IEnumerable<Manufacturer> GetAll()
        {
            return _context.Manufacturers
               .Where(ManufacturerQueries.GetAll())
               .OrderBy(x => x.Description
               );
        }
    }
}