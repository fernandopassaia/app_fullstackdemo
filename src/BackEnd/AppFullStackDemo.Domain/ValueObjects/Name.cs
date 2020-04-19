using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Validate();
        }

        protected Name()
        {
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .HasMinLen(FirstName, 2, "FirstName", "Please Inform a First name.")
                .HasMaxLengthIfNotNullOrEmpty(FirstName, 40, "FirstName", "First name cannot be higher than 40c.")
                .HasMinLen(LastName, 2, "LastName", "Please Inform a Last name.")
                .HasMaxLengthIfNotNullOrEmpty(LastName, 80, "LastName", "Last name cannot be higher than 40c.")
            );
        }

        //in a Company could be SocialName
    }
}