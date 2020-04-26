using AppFullStackDemo.Domain.Commands;
using AppFullStackDemo.Domain.Commands.User;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Handlers.Contracts;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Domain.ValueObjects;
using Flunt.Notifications;

namespace AppFullStackDemo.Domain.Handlers
{
    public class UserHandler :
        Notifiable,
        IHandler<CreateUserCommand>,
        IHandler<UpdateUserCommand>,
        IHandler<LoginUserCommand>
    {
        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public IBaseCommandResult Handle(CreateUserCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new BaseCommandResult(false, "Need to fix the errors on User", command.Notifications);

            // if i pass the validation, i should create a new user
            var user = new User(command.AditionalInfo,
                new Name(command.FirstName, command.LastName),
                new Document(command.CountryRegistryNumber, command.StateRegistryNumber),
                new Phone(command.PhoneNumber1, command.PhoneNumber2, command.MobilePhoneNumber1, command.MobilePhoneNumber2),
                new Email(command.EmailAddress),
                new Address(command.Street, command.StreetNumber, command.NeighborHood, command.City, command.ZipCode),
                new UserAccount(command.UserName, command.Password));

            // Save on Database
            _repository.Create(user);

            // Return the Value
            return new BaseCommandResult(true, "User Saved with Success!", user);
        }

        public IBaseCommandResult Handle(UpdateUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new BaseCommandResult(false, "Need to fix the errors on User", command.Notifications);

            var user = _repository.GetById(command.Id);
            if (user == null)
                return new BaseCommandResult(false, "User not found", null);

            user.Update(command.AditionalInfo,
                new Name(command.FirstName, command.LastName),
                new Document(command.CountryRegistryNumber, command.StateRegistryNumber),
                new Phone(command.PhoneNumber1, command.PhoneNumber2, command.MobilePhoneNumber1, command.MobilePhoneNumber2),
                new Email(command.EmailAddress),
                new Address(command.Street, command.StreetNumber, command.NeighborHood, command.City, command.ZipCode),
                new UserAccount(command.UserName, command.Password));

            _repository.Update(user);

            return new BaseCommandResult(true, "User Updated with Success!", user);
        }

        public IBaseCommandResult Handle(LoginUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new BaseCommandResult(false, "Cannot login because invalid information", command.Notifications);

            var user = _repository.GetByLogin(command.UserName);
            if (user == null)
                return new BaseCommandResult(false, "UserName or PassWord invalid", command.Notifications);

            if (!user.UserAccount.Authenticate(command.UserName, command.Password))
                return new BaseCommandResult(false, "UserName or PassWord invalid", command.Notifications);

            //TO-DO: Need to load the CLAIMS here and return on Obj instead of user
            return new BaseCommandResult(true, "Login with Success", user);
        }
    }
}