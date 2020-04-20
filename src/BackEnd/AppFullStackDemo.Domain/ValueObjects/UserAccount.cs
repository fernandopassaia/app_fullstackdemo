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

            AddNotifications(new Contract()
                .HasMaxLengthIfNotNullOrEmpty(UserName, 100, "Username", "Nome Usuário não pode ser maior que 100 caracters.")
            );
        }

        public string Password { get; private set; }

        public string UserName { get; private set; }

        public bool Authenticate(string username, string password)
        {
            if (UserName == username && Password == EncryptDecryptData.Encrypt(password))
                return true;

            AddNotification("User", "User or PassWord invalid");
            return false;
        }
    }
}