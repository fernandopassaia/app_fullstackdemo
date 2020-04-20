namespace AppFullStackDemo.Domain.Commands.Entities
{
    public class UpdateUserCommand
    {
        public string AditionalInfo { get; private set; }
        public string CountryRegistryNumber { get; private set; }
        public string StateRegistryNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MobilePhoneNumber1 { get; private set; }
        public string MobilePhoneNumber2 { get; private set; }
        public string PhoneNumber1 { get; private set; }
        public string PhoneNumber2 { get; private set; }
        public string City { get; private set; }
        public string NeighborHood { get; private set; }
        public string Street { get; private set; }
        public string StreetNumber { get; private set; }
        public string ZipCode { get; private set; }
    }
}