using AppFullStackDemo.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.Commands.User
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public CreateUserCommand()
        {
        }

        public CreateUserCommand(string aditionalInfo, string countryRegistryNumber, string stateRegistryNumber, string emailAddress, string firstName, string lastName, string mobilePhoneNumber1, string mobilePhoneNumber2, string phoneNumber1, string phoneNumber2, string city, string neighborHood, string street, string streetNumber, string zipCode, string userName, string password)
        {
            AditionalInfo = aditionalInfo;
            CountryRegistryNumber = countryRegistryNumber;
            StateRegistryNumber = stateRegistryNumber;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            MobilePhoneNumber1 = mobilePhoneNumber1;
            MobilePhoneNumber2 = mobilePhoneNumber2;
            PhoneNumber1 = phoneNumber1;
            PhoneNumber2 = phoneNumber2;
            City = city;
            NeighborHood = neighborHood;
            Street = street;
            StreetNumber = streetNumber;
            ZipCode = zipCode;
            UserName = userName;
            Password = password;
        }

        public string AditionalInfo { get; set; }
        public string CountryRegistryNumber { get; set; }
        public string StateRegistryNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhoneNumber1 { get; set; }
        public string MobilePhoneNumber2 { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string City { get; set; }
        public string NeighborHood { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            // Note: On the Create I`ll allow user to create just with First and LastName, Username (email) and Password.
            // Once User is logged, if user tries to UPDATE the profile, will be forced to add Address, Phone and other info.
            AddNotifications(new Contract()
                .HasMaxLengthIfNotNullOrEmpty(UserName, 100, "Username", "UserName cannot be higher than 100c.")
                //Address
                .HasMaxLengthIfNotNullOrEmpty(Street, 120, "Street", "Street needs to be lower than 120c.")
                .HasMaxLengthIfNotNullOrEmpty(StreetNumber, 20, "StreetNumber", "Street Number needs to be lower than 20c.")
                .HasMaxLengthIfNotNullOrEmpty(NeighborHood, 60, "NeighborHood", "Neighboorhood needs to be lower than 60c")
                .HasMaxLengthIfNotNullOrEmpty(City, 60, "City", "City needs to be lower than 60c")
                .HasMaxLengthIfNotNullOrEmpty(ZipCode, 10, "ZipCode", "Zipcode needs to be lower than 10c")
                .HasMaxLengthIfNotNullOrEmpty(CountryRegistryNumber, 20, "CountryRegistryNumber", "Country Register Number Cannot be higher than 20.")
                .HasMaxLengthIfNotNullOrEmpty(StateRegistryNumber, 20, "StateRegistryNumber", "State Register Number Cannot be higher than 20.")
                //Document
                .HasMaxLengthIfNotNullOrEmpty(CountryRegistryNumber, 20, "CountryRegistryNumber", "Country Register Number Cannot be higher than 20.")
                .HasMaxLengthIfNotNullOrEmpty(StateRegistryNumber, 20, "StateRegistryNumber", "State Register Number Cannot be higher than 20.")
                //Email
                .IsEmail(EmailAddress, "EmailAddress", "Please inform a valid email")
                .HasMaxLengthIfNotNullOrEmpty(EmailAddress, 100, "EmailAddress", "Email cannot be higher than 100c")
                //Name
                .HasMinLen(FirstName, 2, "FirstName", "Please Inform a First name.")
                .HasMaxLengthIfNotNullOrEmpty(FirstName, 40, "FirstName", "First name cannot be higher than 40c.")
                .HasMinLen(LastName, 2, "LastName", "Please Inform a Last name.")
                .HasMaxLengthIfNotNullOrEmpty(LastName, 80, "LastName", "Last name cannot be higher than 40c.")
                //Phone
                .HasMaxLengthIfNotNullOrEmpty(PhoneNumber1, 20, "PhoneNumber1", "Phone Number 1 Cannot be Higher 20c.")
                .HasMaxLengthIfNotNullOrEmpty(PhoneNumber2, 20, "PhoneNumber2", "Phone Number 2 Cannot be Higher 20c.")
                .HasMaxLengthIfNotNullOrEmpty(MobilePhoneNumber1, 20, "MobilePhoneNumber1", "Mobile Phone Number 1 Cannot be Higher 20c.")
                .HasMaxLengthIfNotNullOrEmpty(MobilePhoneNumber2, 20, "MobilePhoneNumber2", "Mobile Phone Number 2 Cannot be Higher 20c.")
            );
        }
    }
}