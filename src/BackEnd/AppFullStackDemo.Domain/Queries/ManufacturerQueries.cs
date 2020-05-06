using System;
using System.Linq.Expressions;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Enums;

namespace AppFullStackDemo.Domain.Queries
{
    public static class ManufacturerQueries
    {
        public static Expression<Func<Manufacturer, bool>> GetAll()
        {
            return x => x.Status == ECommonStatus.Active; // && x.Done == true;
        }

        public static Expression<Func<Manufacturer, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}