using System;
using System.Collections.Generic;
using AppFullStackDemo.Domain.Commands.User;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Entities.Security;
using AppFullStackDemo.Domain.Handlers.Contracts;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Domain.Repositories.Security;
using AppFullStackDemo.Domain.Results;
using AppFullStackDemo.Domain.Results.User;
using AppFullStackDemo.Domain.ValueObjects;
using Flunt.Notifications;

namespace AppFullStackDemo.Domain.Handlers
{
    public class UserHandler :
        Notifiable,
        IHandler<CreateUserCommand>,
        IHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUserClaimRepository _userClaimRepository;
        private readonly IClaimRepository _claimRepository;

        public UserHandler(IUserRepository repository, IUserClaimRepository userClaimRepository, IClaimRepository claimRepository)
        {
            _repository = repository;
            _userClaimRepository = userClaimRepository;
            _claimRepository = claimRepository;
        }

        public IBaseCommandResult Handle(CreateUserCommand command)
        {
            _repository.MockDataCreator(); //note: When i create my first user, database will be filled with TEST data. Comment this line if you don't want it.

            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new BaseCommandResult(false, "Need to fix the errors on User", command.Notifications);

            var userByUsername = _repository.GetByLogin(command.UserName);
            if (userByUsername != null)
                return new BaseCommandResult(true, "Username Already exists.", null);

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

            // Note: Here I`ll simply add all CLAIMS to this New User, so basically the user will access everything. As described in README.MD
            // you should adapt this rule to your business (like creating claims based on a "Profile" or a Screen to select claims to the user)
            // because this sample is not a sample of "real business" but development, we will simply give user all claims.
            var claims = _claimRepository.Get();
            var claimsForUser = new List<UserClaim>();
            foreach (Claim cla in claims)
            {
                claimsForUser.Add(new UserClaim(user, cla));
            }

            _userClaimRepository.AddUserClaims(claimsForUser);
            // Return the Value
            return new BaseCommandResult(true, "User Saved with Success! You can use it for login now.", null);
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

            return new BaseCommandResult(true, "User Updated with Success!", null);
        }

        public IBaseCommandResult Handle(Guid id)
        {
            var user = _repository.GetById(id);
            if (user == null)
                return new BaseCommandResult(false, "User not found", null);

            user.Remove();
            _repository.Update(user);
            return new BaseCommandResult(true, "User Deleted with Success!", null);
        }

        public GetLoggedUserResult Handle(LoginUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GetLoggedUserResult(false, "Cannot login because invalid information", "", "", "", "", null);

            var user = _repository.GetByLogin(command.UserName);
            if (user == null)
                return new GetLoggedUserResult(false, "Cannot find UserName or Password", "", "", "", "", null);

            if (!user.UserAccount.Authenticate(command.UserName, command.Password))
                return new GetLoggedUserResult(false, "Cannot find UserName or Password", "", "", "", "", null);

            // If pass, user was authenticated, so i need to get the claims
            var userClaim = _userClaimRepository.GetByUser(user);
            List<string> Claims = new List<string>();

            foreach (UserClaim item in userClaim)
            {
                Claims.Add(item.Claim.ClaimName);
            }

            //TO-DO: Need to load the CLAIMS here and return on Obj instead of user
            return new GetLoggedUserResult(true, "Logged with Success.", user.Id.ToString(), user.Name.ToString(), user.Email.EmailAddress.ToString(), user.UserAccount.UserName, Claims);
        }
    }
}