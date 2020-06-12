using System;
using System.Collections.Generic;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Results.User;

namespace AppFullStackDemo.Domain.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        void Update(User user);
        User GetById(Guid id);
        User GetByLogin(string userName);
        IEnumerable<GetUserResumed> GetUsers();
        GetUserResult GetUser(Guid id);
        bool MockDataCreator();
    }
}