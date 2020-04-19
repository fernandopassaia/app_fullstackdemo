using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(string countryRegistryNumber, string stateRegistryNumber, string cityRegistryNumber)
        {
            CountryRegistryNumber = countryRegistryNumber;
            StateRegistryNumber = stateRegistryNumber;
            CityRegistryNumber = cityRegistryNumber;
            Validate();
        }

        protected Document()
        {
        }

        public string CityRegistryNumber { get; private set; }

        public string CountryRegistryNumber { get; private set; }

        public string StateRegistryNumber { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .HasMaxLengthIfNotNullOrEmpty(CountryRegistryNumber, 20, "CountryRegistryNumber", "Country Register Number Cannot be higher than 20.")
                .HasMaxLengthIfNotNullOrEmpty(StateRegistryNumber, 20, "StateRegistryNumber", "State Register Number Cannot be higher than 20.")
                .HasMaxLengthIfNotNullOrEmpty(CityRegistryNumber, 20, "CityRegistryNumber", "City Register Number Cannot be higher than 20.")
            );

            // Note: this validation was commented because it's specific to BRAZILIAN documents, so if you are BR, you can uncomment and use it.
            // If you belongs to other Country and also has a way to validate Documents from your country, please insert logic on "FieldsValidation.cs"
            //if (CountryRegistryNumber.Length > 10 && !FieldsValidations.ValidateCountryRegistryNumber(CountryRegistryNumber))
            //    AddNotification("CountryRegistryNumber", "Por favor informe o CPF/CNPJ Válido.");
        }
    }
}