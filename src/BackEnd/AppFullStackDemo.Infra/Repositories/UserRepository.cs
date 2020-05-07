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

        public User GetByLogin(string userName)
        {
            return _context.Users
                .AsNoTracking()
                .Where(UserQueries.GetByLogin(userName))
                .FirstOrDefault();
        }

        public IEnumerable<GetUserResumed> GetUsers()
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

        public GetUserResult GetUser(Guid id)
        {
            var data = _context.Users
               .Where(UserQueries.GetById(id))
               .FirstOrDefault();


            if (data == null)
                return null;

            return new GetUserResult
            {
                Id = data.Id.ToString(),
                AditionalInfo = data.AditionalInfo,
                CountryRegistryNumber = data.Document.CountryRegistryNumber,
                StateRegistryNumber = data.Document.StateRegistryNumber,
                EmailAddress = data.Email.EmailAddress,
                FirstName = data.Name.FirstName,
                LastName = data.Name.LastName,
                MobilePhoneNumber1 = data.Phone.MobilePhoneNumber1,
                MobilePhoneNumber2 = data.Phone.MobilePhoneNumber2,
                PhoneNumber1 = data.Phone.PhoneNumber1,
                PhoneNumber2 = data.Phone.PhoneNumber2,
                City = data.Address.City,
                NeighborHood = data.Address.NeighborHood,
                Street = data.Address.Street,
                StreetNumber = data.Address.StreetNumber,
                ZipCode = data.Address.ZipCode,
                UserName = data.UserAccount.UserName,
                Password = data.UserAccount.DecryptPassword(),
                ConfirmPassword = data.UserAccount.DecryptPassword()
            };
        }
    }
}