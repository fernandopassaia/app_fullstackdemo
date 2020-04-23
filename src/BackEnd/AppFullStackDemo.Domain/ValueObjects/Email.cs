using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.ValueObjects
{
    public class Email
    {
        public Email(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        protected Email() { } //This constructor will be used by EF during migrations (for some reason, EF needs a empty constructor to run)

        public string EmailAddress { get; private set; }
    }
}