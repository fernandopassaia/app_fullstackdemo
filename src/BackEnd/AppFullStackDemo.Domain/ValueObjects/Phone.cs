using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.ValueObjects
{
    public class Phone : Notifiable
    {
        public Phone(string phoneNumber1, string phoneNumber2, string mobilePhoneNumber1, string mobilePhoneNumber2)
        {
            PhoneNumber1 = phoneNumber1;
            PhoneNumber2 = phoneNumber2;
            MobilePhoneNumber1 = mobilePhoneNumber1;
            MobilePhoneNumber2 = mobilePhoneNumber2;
            Validate();
        }

        protected Phone()
        {
        }

        public string MobilePhoneNumber1 { get; private set; }

        public string MobilePhoneNumber2 { get; private set; }

        public string PhoneNumber1 { get; private set; }

        public string PhoneNumber2 { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNull(PhoneNumber1, "PhoneNumber1", "Phone Number 1 cannot be null")
                .HasMaxLengthIfNotNullOrEmpty(PhoneNumber1, 20, "PhoneNumber1", "Phone Number 1 Cannot be higher than 20c")
                .HasMaxLengthIfNotNullOrEmpty(MobilePhoneNumber2, 20, "MobilePhoneNumber2", "Phone Number 2 Cannot be higher than 20c")
            );
        }
    }
}