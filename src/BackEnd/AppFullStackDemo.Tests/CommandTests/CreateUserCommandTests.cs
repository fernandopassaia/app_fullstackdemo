using AppFullStackDemo.Domain.Commands.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppFullStackDemo.Tests.CommandTests
{
    [TestClass]
    public class CreateUserCommandTests
    {
        //4 errors: StreetNumberHigherThan4 - NoCity - NoEmailFormat - LastName too small
        private readonly CreateUserCommand _invalidCommand = new CreateUserCommand("", "325-552", "789-654", "noEmailFormat", "Fernando", "P",
            "35-30-892-3557", "", "", "", "", "TerezVaros", "Aradi Utca", "12BHigher4", "8573", "fernandopassaia", "1234Fd");
        private readonly CreateUserCommand _validCommand = new CreateUserCommand("", "325-552", "789-654", "fernandopassaia@futuradata.com.br", "Fernando", "Passaia",
            "35-30-892-3557", "", "", "", "Budapest", "TerezVaros", "Aradi Utca", "12B", "8573", "fernandopassaia", "1234Fd");

        public CreateUserCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void ShouldFail_With4Errors()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
            Assert.AreEqual(_invalidCommand.Notifications.Count, 3); //0-1-2-3
        }

        [TestMethod]
        public void ShouldPass()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
