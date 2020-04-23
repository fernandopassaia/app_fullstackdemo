using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.ValueObjects
{
    public class Address
    {
        public Address(string street, string streetNumber, string neighborHood,
               string city, string postalCode, string zipCode, string state, string country)
        {
            Street = street;
            StreetNumber = streetNumber;
            NeighborHood = neighborHood;
            City = city;
            ZipCode = zipCode;
        }

        protected Address() { } //This constructor will be used by EF during migrations (for some reason, EF needs a empty constructor to run)

        public string City { get; private set; }
        public string NeighborHood { get; private set; }
        public string Street { get; private set; }
        public string StreetNumber { get; private set; }
        public string ZipCode { get; private set; }
    }
}