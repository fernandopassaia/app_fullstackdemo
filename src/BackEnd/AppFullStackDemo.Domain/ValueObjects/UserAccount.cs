using AppFullStackDemo.Shared.Crypt;

namespace AppFullStackDemo.Domain.ValueObjects
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
            var passwordFromDbDecrypted = EncryptDecryptData.Decrypt(Password);

            if (UserName == username && password == passwordFromDbDecrypted)
                return true;
            return false;
        }

        public string DecryptPassword()
        {
            return EncryptDecryptData.Decrypt(Password);
        }
    }
}