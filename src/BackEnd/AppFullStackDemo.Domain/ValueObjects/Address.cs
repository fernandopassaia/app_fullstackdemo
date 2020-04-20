using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.ValueObjects
{
    public class Address : Notifiable
    {
        public Address(string street, string streetNumber, string neighborHood,
               string city, string postalCode, string zipCode, string state, string country)
        {
            Street = street;
            StreetNumber = streetNumber;
            NeighborHood = neighborHood;
            City = city;
            ZipCode = zipCode;
            Validate();
        }

        public string City { get; private set; }
        public string NeighborHood { get; private set; }
        public string Street { get; private set; }
        public string StreetNumber { get; private set; }
        public string ZipCode { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract()
               .IsNotNullOrEmpty(Street, "Street", "Please Inform a Street.")
                .HasMaxLengthIfNotNullOrEmpty(Street, 120, "Street", "Street needs to be lower than 120c.")
                .IsNotNullOrEmpty(StreetNumber, "StreetNumber", "Please Inform a Street Number")
                .HasMaxLengthIfNotNullOrEmpty(StreetNumber, 20, "StreetNumber", "Street Number needs to be lower than 20c.")
                .IsNotNullOrEmpty(NeighborHood, "NeighborHood", "Please Inform a Neighboorhood")
                .HasMaxLengthIfNotNullOrEmpty(NeighborHood, 60, "NeighborHood", "Neighboorhood needs to be lower than 60c")
                .IsNotNullOrEmpty(City, "City", "Please Inform a City.")
                .HasMaxLengthIfNotNullOrEmpty(City, 60, "City", "City needs to be lower than 60c")
                .HasMaxLengthIfNotNullOrEmpty(ZipCode, 10, "ZipCode", "Zipcode needs to be lower than 10c")
            );
        }
    }
}