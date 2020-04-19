using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.ValueObjects
{
    public class Address : Notifiable
    {
        public Address(string street, string streetNumber, string complement, string neighborHood,
               string city, string postalCode, string zipCode, string state, string country)
        {
            Street = street;
            StreetNumber = streetNumber;
            Complement = complement;
            NeighborHood = neighborHood;
            City = city;
            PostalCode = postalCode;
            ZipCode = zipCode;
            State = state;
            Country = country;
            Validate();
        }

        protected Address()
        {
        }

        public string City { get; private set; }

        public string Complement { get; private set; }

        public string Country { get; private set; }

        //could be floor, reference point, etc
        public string NeighborHood { get; private set; }

        public string PostalCode { get; private set; }

        public string State { get; private set; }

        public string Street { get; private set; }

        public string StreetNumber { get; private set; }

        //CEP
        public string ZipCode { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract()
               .IsNotNullOrEmpty(Street, "Street", "Por favor informe um Logradouro.")
                .HasMaxLengthIfNotNullOrEmpty(Street, 120, "Street", "Logradouro não pode ser maior que 120 caracters.")
                .IsNotNullOrEmpty(StreetNumber, "StreetNumber", "Por favor informe um Número Válido")
                .HasMaxLengthIfNotNullOrEmpty(StreetNumber, 20, "StreetNumber", "Número não pode ser maior que 20 caracters")
                .IsNotNullOrEmpty(NeighborHood, "NeighborHood", "Por favor informe um Bairro Válido.")
                .HasMaxLengthIfNotNullOrEmpty(NeighborHood, 60, "NeighborHood", "Bairro não pode ter mais de 60 caracters")
                .IsNotNullOrEmpty(City, "City", "Por favor informe uma Cidade Válida.")
                .HasMaxLengthIfNotNullOrEmpty(City, 60, "City", "Cidade não pode ter mais de 60 caracters")
                .IsNotNullOrEmpty(PostalCode, "PostalCode", "Por favor informe um valor para CEP.")
                .HasMaxLengthIfNotNullOrEmpty(PostalCode, 10, "PostalCode", "CEP não pode ter mais que 10 caracters.")
                .IsNotNullOrEmpty(State, "State", "Por favor informe um valor para Estado.")
                .HasMaxLengthIfNotNullOrEmpty(State, 30, "State", "Estado não pode ser maior que 30 caracters.")
                .IsNotNullOrEmpty(Country, "Country", "País não pode ser maior que 30 caracters.")
                .HasMaxLengthIfNotNullOrEmpty(Country, 30, "Country", "País não pode ser maior que 30 caracters.")

                .HasMaxLengthIfNotNullOrEmpty(Complement, 60, "Complement", "Complemento não pode ser maior que 60 caracters.")
                .HasMaxLengthIfNotNullOrEmpty(ZipCode, 10, "ZipCode", "IBGE não pode ser maior que 10 caracters.")
            );
        }

        //IBGE
    }
}