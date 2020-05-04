using System;
using System.Collections.Generic;
using AppFullStackDemo.Domain.Commands.User;
using AppFullStackDemo.Domain.Entities;

namespace AppFullStackDemo.Domain.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        void Update(User user);
        User GetById(Guid id);
        IEnumerable<User> GetAll();
        User GetByLogin(string userName);
        IEnumerable<GetUserResumed> GetUserResumed();
    }
}