using AppFullStackDemo.Shared.Crypt;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.Entities
{
    public class UserAccount : Notifiable
    {
        public UserAccount(string username, string password)
        {
            UserName = username;
            Password = EncryptDecryptData.Encrypt(password);
            Validate();
        }

        protected UserAccount() { } //This constructor will be used by EF during migrations (for some reason, EF needs a empty constructor to run)

        public string Password { get; private set; }

        public string UserName { get; private set; }

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