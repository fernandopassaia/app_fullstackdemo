using System;
using System.Collections.Generic;
using System.Linq;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Queries;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : IUserRepository
    {
        private readonly AppFullStackDemoContext _context;

        public TodoRepository(AppFullStackDemoContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public User GetById(Guid id)
        {
            return _context
                .Users
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users
               .Where(UserQueries.GetAll())
               .OrderBy(x => x.Name.FirstName);
        }

        public User GetByLogin(string userName)
        {
            return _context.Users
                .AsNoTracking()
                .Where(UserQueries.GetByLogin(userName))
                .FirstOrDefault();
        }
    }
}