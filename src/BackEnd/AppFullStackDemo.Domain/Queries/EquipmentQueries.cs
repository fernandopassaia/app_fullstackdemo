using System;
using System.Linq.Expressions;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Enums;

namespace AppFullStackDemo.Domain.Queries
{
    public static class EquipmentQueries
    {
        public static Expression<Func<Equipment, bool>> GetAll()
        {
            return x => x.Status == ECommonStatus.Active; // && x.Done == true;
        }
    }
}