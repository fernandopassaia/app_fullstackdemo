using AppFullStackDemo.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.Commands.User
{
    public class LoginUserCommand : Notifiable, ICommand
    {
        public LoginUserCommand()
        {
        }

        public LoginUserCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(UserName, "UserName", "Please Inform a UserName.")
                .IsNotNullOrEmpty(Password, "Password", "Please Inform a Password.")
            );
        }
    }
}