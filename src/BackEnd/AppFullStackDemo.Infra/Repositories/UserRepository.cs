using System;
using System.Collections.Generic;
using System.Linq;
using AppFullStackDemo.Domain.Commands.User;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Queries;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace AppFullStackDemo.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppFullStackDemoContext _context;

        public UserRepository(AppFullStackDemoContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
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

        public IEnumerable<GetUserResumed> GetUserResumed()
        {
            var data = _context.Users
               .Where(UserQueries.GetAll())
               .OrderBy(x => x.Name.FirstName)
               .ToList();

            if (data == null)
                return null;

            return data.Select(reg => new GetUserResumed
            {
                Id = reg.Id.ToString(),
                Name = reg.Name.ToString(),
                Email = reg.Email.EmailAddress,
                City = reg.Address.City
            });
        }
    }
}