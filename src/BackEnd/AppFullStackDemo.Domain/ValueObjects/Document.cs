using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(string countryRegistryNumber, string stateRegistryNumber)
        {
            CountryRegistryNumber = countryRegistryNumber;
            StateRegistryNumber = stateRegistryNumber;
            Validate();
        }

        protected Document() { } //This constructor will be used by EF during migrations (for some reason, EF needs a empty constructor to run)

        public string CountryRegistryNumber { get; private set; }

        public string StateRegistryNumber { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .HasMaxLengthIfNotNullOrEmpty(CountryRegistryNumber, 20, "CountryRegistryNumber", "Country Register Number Cannot be higher than 20.")
                .HasMaxLengthIfNotNullOrEmpty(StateRegistryNumber, 20, "StateRegistryNumber", "State Register Number Cannot be higher than 20.")
            );
        }
    }
}