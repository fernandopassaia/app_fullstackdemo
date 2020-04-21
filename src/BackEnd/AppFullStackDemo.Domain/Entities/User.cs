using AppFullStackDemo.Domain.Entities.Security;
using AppFullStackDemo.Domain.ValueObjects;
using Flunt.Validations;
using System.Collections.Generic;

namespace AppFullStackDemo.Domain.Entities
{
    public class User : EntityBase
    {
        public User(string aditionalInfo, Name name, Document document, Phone phone, Email email, Address address, UserAccount userAccount)
        {
            AditionalInfo = aditionalInfo;
            Name = name;
            Document = document;
            Phone = phone;
            Email = email;
            Address = address;
            UserAccount = userAccount;
            Validate();
        }

        protected User() { } //This constructor will be used by EF during migrations (for some reason, EF needs a empty constructor to run)

        //Parameters and ObjectValues
        public string AditionalInfo { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Name Name { get; private set; }
        public Phone Phone { get; private set; }
        public Address Address { get; private set; }
        public UserAccount UserAccount { get; private set; }

        //User has a collection of Equipments and a List of Claims
        public List<Equipment> EquipmentsList { get; private set; }
        public List<UserClaim> UserClaimList { get; private set; }

        public void Update(string aditionalInfo, Name name, Document document, Phone phone, Email email, Address address, UserAccount userAccount)
        {
            AditionalInfo = aditionalInfo;
            Name = name;
            Document = document;
            Phone = phone;
            Email = email;
            Address = address;
            UserAccount = userAccount;
            Validate();
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .HasMaxLengthIfNotNullOrEmpty(AditionalInfo, 200, "AditionalInfo", "Aditional Info could not be higger than 200c")
            );
        }
    }
}