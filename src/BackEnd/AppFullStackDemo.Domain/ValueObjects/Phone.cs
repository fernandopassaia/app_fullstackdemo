using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.ValueObjects
{
    public class Phone
    {
        public Phone(string phoneNumber1, string phoneNumber2, string mobilePhoneNumber1, string mobilePhoneNumber2)
        {
            PhoneNumber1 = phoneNumber1;
            PhoneNumber2 = phoneNumber2;
            MobilePhoneNumber1 = mobilePhoneNumber1;
            MobilePhoneNumber2 = mobilePhoneNumber2;
        }

        protected Phone() { } //This constructor will be used by EF during migrations (for some reason, EF needs a empty constructor to run)

        public string MobilePhoneNumber1 { get; private set; }

        public string MobilePhoneNumber2 { get; private set; }

        public string PhoneNumber1 { get; private set; }

        public string PhoneNumber2 { get; private set; }
    }
}