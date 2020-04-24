using AppFullStackDemo.Domain.Commands;
using AppFullStackDemo.Domain.Commands.User;
using AppFullStackDemo.Domain.Handlers;
using AppFullStackDemo.Infra.Context;
using AppFullStackDemo.Infra.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppFullStackDemo.Tests.HandlersTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        //4 errors: StreetNumberHigherThan4 - NoCity - NoEmailFormat - LastName too small
        private readonly CreateUserCommand _invalidCommand = new CreateUserCommand("", "325-552", "789-654", "noEmailFormat", "Fernando", "P",
            "35-30-892-3557", "", "", "", "", "TerezVaros", "Aradi Utca", "12BHigher4", "8573", "fernandopassaia", "1234Fd");
        private readonly CreateUserCommand _validCommand = new CreateUserCommand("", "325-552", "789-654", "fernandopassaia@futuradata.com.br", "Fernando", "Passaia",
            "35-30-892-3557", "", "", "", "Budapest", "TerezVaros", "Aradi Utca", "12B", "8573", "fernandopassaia", "1234Fd");

        private readonly LoginUserCommand _validLoginUser = new LoginUserCommand("admin", "admin");
        private readonly LoginUserCommand _invalidLoginUser = new LoginUserCommand("admin", "WrongPassword");

        //Note: Repository will use the EF Context, and here there's not DI, so the Default ConnectionString on class will be used
        private UserRepository _repository = new UserRepository(new AppFullStackDemoContext());
        private readonly UserHandler _handler;
        private BaseCommandResult _result = new BaseCommandResult();

        public CreateTodoHandlerTests()
        {
            _handler = new UserHandler(_repository);
        }

        [TestMethod]
        public void HandlerShouldFail_OnCreateUser()
        {
            _result = (BaseCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void HandlerShouldPass_OnCreateUser()
        {
            _result = (BaseCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }

        [TestMethod]
        public void Handle_ShouldNotLoginAUser()
        {
            _result = (BaseCommandResult)_handler.Handle(_invalidLoginUser);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Handle_ShouldLoginAUser()
        {
            _result = (BaseCommandResult)_handler.Handle(_validLoginUser);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
