using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string emailAddress)
        {
            EmailAddress = emailAddress;
            Validate();
        }

        protected Email() { } //This constructor will be used by EF during migrations (for some reason, EF needs a empty constructor to run)

        public string EmailAddress { get; private set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .IsEmail(EmailAddress, "EmailAddress", "Please inform a valid email")
                .IsNotNull(EmailAddress, "EmailAddress", "Email cannot be null")
                .HasMaxLengthIfNotNullOrEmpty(EmailAddress, 100, "EmailAddress", "Email cannot be higher than 100c")
            );
        }
    }
}