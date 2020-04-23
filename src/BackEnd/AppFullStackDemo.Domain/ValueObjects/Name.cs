using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.ValueObjects
{
    public class Name
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        protected Name() { } //This constructor will be used by EF during migrations (for some reason, EF needs a empty constructor to run)

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}