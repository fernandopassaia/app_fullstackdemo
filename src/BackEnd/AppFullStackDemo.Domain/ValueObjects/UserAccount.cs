using AppFullStackDemo.Shared.Crypt;
using Flunt.Notifications;

namespace AppFullStackDemo.Domain.Entities
{
    public class UserAccount
    {
        public UserAccount(string username, string password)
        {
            UserName = username;
            Password = EncryptDecryptData.Encrypt(password);
        }

        protected UserAccount() { } //This constructor will be used by EF during migrations (for some reason, EF needs a empty constructor to run)

        public string Password { get; private set; }

        public string UserName { get; private set; }

        public bool Authenticate(string username, string password)
        {
            if (UserName == username && Password == EncryptDecryptData.Encrypt(password))
                return true;
            return false;
        }
    }
}