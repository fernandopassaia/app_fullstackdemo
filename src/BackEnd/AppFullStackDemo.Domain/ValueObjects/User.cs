using Flunt.Notifications;
using Flunt.Validations;
using AppFullStackDemo.Shared.Crypt;
using System.Text;

namespace AppFullStackDemo.Domain.ValueObjects
{
    public class User : Notifiable
    {
        public User(string username, string password)
        {
            UserName = username;
            Password = EncryptDecryptData.Encrypt(password);
            Validate();
        }

        protected User() { } //This constructor will be used by EF during migrations (for some reason, EF needs a empty constructor to run)

        public string Password { get; private set; }

        public string UserName { get; private set; }

        public void updatePassword(string password)
        {
            Password = EncryptDecryptData.Encrypt(password);
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .HasMaxLengthIfNotNullOrEmpty(UserName, 100, "Username", "UserName cannot be higher than 100c.")
            );
        }

        public bool Authenticate(string username, string password)
        {
            if (UserName == username && Password == EncryptDecryptData.Encrypt(password))
                return true;

            AddNotification("User", "User or PassWord invalid");
            return false;
        }
    }
}