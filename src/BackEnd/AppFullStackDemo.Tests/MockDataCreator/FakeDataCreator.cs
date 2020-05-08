using System.Linq;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Entities.Security;
using AppFullStackDemo.Domain.ValueObjects;
using AppFullStackDemo.Infra.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppFullStackDemo.Tests.MockDataCreator
{
    [TestClass]
    public class FakeDataCreator
    {
        AppFullStackDemoContext _context = new AppFullStackDemoContext();
        public FakeDataCreator()
        {

        }

        [TestMethod]
        public void CreateFakeMockData()
        {
            if (!_context.Users.Any()) //before insert data I'll check if db is empty
            {
                var users = new User[] {
                    new User("Created by loadFakeData",
                    new Name("Admin", "SystemAdmin"),
                    new Document("33557788-9", "55448899"),
                    new Phone("36-555-777", "", "", ""),
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
        }
    }
}
