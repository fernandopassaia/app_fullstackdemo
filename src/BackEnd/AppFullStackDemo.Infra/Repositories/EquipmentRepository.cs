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
            _context.SaveChanges();
        }

        public void Update(Equipment equipment)
        {
            _context.Entry(equipment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Equipment GetById(Guid id)
        {
            return _context
                .Equipments
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _context.Equipments
               .Where(EquipmentQueries.GetAll())
               .OrderBy(x => x.ApiLevel
               );
        }
    }
}