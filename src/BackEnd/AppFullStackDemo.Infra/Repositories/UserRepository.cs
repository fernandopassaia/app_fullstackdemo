using System;
using System.Collections.Generic;
using System.Linq;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Entities.Security;
using AppFullStackDemo.Domain.Queries;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Domain.Results.User;
using AppFullStackDemo.Domain.ValueObjects;
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

        public bool MockDataCreator()
        {
            // Note By Fernando: This is a small "hack" to avoid the system to be initialized without Test-Data (FakeData). I've created this method to
            // Feed data and fill database with some tests info, that will display a better and most complete panel with some Manufacturers, Models...
            // You can skip the call of this method by commenting the line on UserHandler > Handle(CreateUser)

            var usersOnDb = GetUsers().ToList();

            if (usersOnDb.Count == 0)
            {
                var users = new User[] {
                    new User("Created by loadFakeData",
                    new Name("Admin", "SystemAdmin"),
                    new Document("33557788-9", "55448899"),
                    new Phone("3699955566", "", "", ""),
                    new Email("admin@appfullstackdemo.com"),
                    new Address("Street Api", "12", "Solid Village", "City of NetCore", "7788"),
                    new UserAccount("admin", "admin")
                )};
                    _context.Users.AddRange(users);
                    _context.SaveChanges(); //I'm calling SaveChanges each time because i need DB to generate the Guids then it will be stored here to the Fks

                    var manufacturers = new Manufacturer[] {
                    new Manufacturer("Xiaomi"),
                    new Manufacturer("Motorola"),
                    new Manufacturer("Samsung"),
                    new Manufacturer("LG")
                };
                    _context.Manufacturers.AddRange(manufacturers);
                    _context.SaveChanges();

                    var deviceModels = new DeviceModel[] {
                    new DeviceModel("Mi Max 2", manufacturers[0]),//0
                    new DeviceModel("Redmi Note 10", manufacturers[0]),//1
                    new DeviceModel("Moto G8", manufacturers[1]),//2
                    new DeviceModel("Galaxy S20 Plus", manufacturers[2]),//3
                    new DeviceModel("Galaxy S10e", manufacturers[2]),//4
                    new DeviceModel("LG V60", manufacturers[3]),//5
                };
                    _context.DeviceModels.AddRange(deviceModels);
                    _context.SaveChanges();

                    var claims = new Claim[] {
                    new Claim("dashboard", ""),
                    new Claim("manufacturer", ""),
                    new Claim("devicemodel", ""),
                    new Claim("user", ""),
                    new Claim("equipment", ""),
                };
                    _context.Claims.AddRange(claims);
                    _context.SaveChanges();

                    var userClaims = new UserClaim[] {
                    new UserClaim(users[0], claims[0]),
                    new UserClaim(users[0], claims[1]),
                    new UserClaim(users[0], claims[2]),
                    new UserClaim(users[0], claims[3]),
                    new UserClaim(users[0], claims[4]),
                };
                    _context.UserClaims.AddRange(userClaims);
                    _context.SaveChanges();

                    var equipments = new Equipment[] {
                    new Equipment("8c4997076d138ae6", "864166044650604", "864167058640512", "36-555-777", "EC:D0:8F:2F:09:D5", "25",
                    "Android 7.1", "5588997788234", "Android", "7.1.1", deviceModels[0], users[0]), //mimax2
                    new Equipment("8c4997076d138bc6", "864166044650605", "864167058640513", "36-555-778", "EC:D0:8F:2F:09:D1", "25",
                    "Android 7.1", "5588997788231", "Android", "7.1.1", deviceModels[1], users[0]), //note10
                    new Equipment("8c4997076d138bd6", "864166044650655", "864167058640556", "36-555-790", "EC:D0:8F:2F:09:D6", "27",
                    "Android 8.1", "5588997788333", "Android", "8.1", deviceModels[1], users[0]), //note10
                    new Equipment("8c4997076d138ae7", "864166044650603", "864167058640514", "36-555-779", "EC:D0:8F:2F:09:D7", "27",
                    "Android 8.1", "5588997788232", "Android", "8.1", deviceModels[2], users[0]), //g8
                    new Equipment("8c4997076d138cc7", "864166044650601", "864167058640517", "36-555-780", "EC:D0:8F:2F:09:D2", "27",
                    "Android 8.1", "5588997788235", "Android", "8.1", deviceModels[3], users[0]), //s20
                    new Equipment("8c4997076d138dc7", "864166044650608", "864167058640518", "36-555-781", "EC:D0:8F:2F:09:D3", "27",
                    "Android 8.1", "5588997788236", "Android", "8.1", deviceModels[4], users[0]), //ss10e
                    new Equipment("8c4997076d138cc7", "864166044650602", "864167058640519", "36-555-784", "EC:D0:8F:2F:09:D8", "28",
                    "Android 9", "5588997788245", "Android", "9", deviceModels[5], users[0]), //v60                
                };
                _context.Equipments.AddRange(equipments);
                _context.SaveChanges();
            }
            return true;
        }
    }
}