// This is a helper class to generate Mock Data during the First Run of the System (if there's no data, will insert some mock/fake data)
// This class is not following any pattern once the only reason here is to fill some fake data on DB. The better approach for it is to
// Create some project to fill the DataBase (like a consoleapp) or even a TEST project if i Want to Generate some data. Anyway...

using System.Linq;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Entities.Security;
using AppFullStackDemo.Domain.ValueObjects;
using AppFullStackDemo.Infra.Context;

namespace AppFullStackDemo.Infra.Data
{
    public static class SeedMockDataCreator
    {
        public static void CreateMockData(AppFullStackDemoContext _context)
        {
            if (!_context.User.Any()) //before insert data I'll check if db is empty
            {
                var users = new User[] {
                    new User("Created by loadFakeData",
                    new Name("Admin", "SystemAdmin"),
                    new Document("33557788-9", "55448899"),
                    new Phone("36-555-777", "", "", ""),
                    new Email("admin@appfullstackdemo.com"),
                    new Address("Street Api", "12", "Solid Village", "City of NetCore", "7788", "7878-15", "Province of Angular", "Programming Country"),
                    new UserAccount("admin", "admin")
            )};
                _context.User.AddRange(users);
                _context.SaveChanges(); //I'm calling SaveChanges each time because i need DB to generate the Guids then it will be stored here to the Fks

                var manufacturers = new Manufacturer[] {
                new Manufacturer("Xiaomi")
            };
                _context.Manufacturer.AddRange(manufacturers);
                _context.SaveChanges();

                var deviceModels = new DeviceModel[] {
                new DeviceModel("MI MAX 2", manufacturers[0])
            };
                _context.DeviceModel.AddRange(deviceModels);
                _context.SaveChanges();

                var claims = new Claim[] {
                new Claim("dashboard", ""),
                new Claim("manufacturer", ""),
                new Claim("devicemodel", ""),
                new Claim("user", ""),
                new Claim("equipment", ""),
            };
                _context.Claim.AddRange(claims);
                _context.SaveChanges();

                var userClaims = new UserClaim[] {
                new UserClaim(users[0], claims[0]),
                new UserClaim(users[0], claims[1]),
                new UserClaim(users[0], claims[2]),
                new UserClaim(users[0], claims[3]),
                new UserClaim(users[0], claims[4]),
            };
                _context.UserClaim.AddRange(userClaims);
                _context.SaveChanges();

                var equipments = new Equipment[] {
                new Equipment("8c4997076d138ae6", "864166044650604", "864167058640512", "36-555-777", "EC:D0:8F:2F:09:D5", "25",
                "Android 7.1", "5588997788234", "Android", "7.1.1", deviceModels[0], users[0])
            };
                _context.Equipment.AddRange(equipments);
                _context.SaveChanges();
            }
        }
    }
}
