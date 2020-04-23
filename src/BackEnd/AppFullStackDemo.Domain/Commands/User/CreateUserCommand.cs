namespace AppFullStackDemo.Domain.Commands.User
{
    public class CreateUserCommand
    {
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
    }
}