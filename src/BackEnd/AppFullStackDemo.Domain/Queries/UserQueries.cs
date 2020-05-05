using System;
using System.Linq.Expressions;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Enums;

namespace AppFullStackDemo.Domain.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> GetByLogin(string userName)
        {
            return x => x.UserAccount.UserName == userName;
        }

        public static Expression<Func<User, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<User, bool>> GetAll()
        {
            return x => x.Status == ECommonStatus.Active; // && x.Done == true;
        }
    }
}