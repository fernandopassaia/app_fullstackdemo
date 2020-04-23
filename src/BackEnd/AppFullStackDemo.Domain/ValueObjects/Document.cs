using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.ValueObjects
{
    public class Document
    {
        public Document(string countryRegistryNumber, string stateRegistryNumber)
        {
            CountryRegistryNumber = countryRegistryNumber;
            StateRegistryNumber = stateRegistryNumber;
        }

        protected Document() { } //This constructor will be used by EF during migrations (for some reason, EF needs a empty constructor to run)

        public string CountryRegistryNumber { get; private set; }

        public string StateRegistryNumber { get; private set; }
    }
}