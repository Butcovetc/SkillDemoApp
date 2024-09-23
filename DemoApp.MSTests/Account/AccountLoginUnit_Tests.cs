using DemoApp.Model.Dal.Requests;
using DemoApp.Model.DbContext.Entity;
using DemoApp.Model.Services.Interfaces;
using DemoApp.Model.Utils;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Monee.Logic.DbLayer;

namespace DemoApp.MSTests.Account
{
    [TestClass]
    public class AccountLoginUnit_Tests : TestInitializerBase
    {
        IAccountService _service;
        private IServiceScope _scope;


        /// <summary>
        /// Database context
        /// </summary>
        DataBaseContext Context => _scope.ServiceProvider.GetRequiredService<DataBaseContext>();

        [TestInitialize]
        public void TestInitializeMethod()
        {
            ConfigureServieProvider();

            _scope = base.ServiceProvider.CreateScope();
            _service = _scope.ServiceProvider.GetRequiredService<IAccountService>();
        }

        [TestCleanup]
        public void TestCleanupMethod()
        {
            if (_scope != null)
                _scope.Dispose();
        }

        [TestMethod]
        public void AccountLoginUnit_Success_Test()
        {
            var context = Context;
            var pass = Faker.StringFaker.AlphaNumeric(10);
            var user = new ApplicationUserEntity
            {
                Login = Faker.InternetFaker.Email(),
                PassHash = CryptoFacade.EncryptPass(pass)
            };

            context.Users.Add(user);

            context.SaveChanges();

            var reqLogin = new ReqLogin
            {
                Login = user.Login,
                Password = pass
            };

            var result = _service.LoginAsync(reqLogin).Result;  

            result.Should().NotBeNull();
            result.Error.Should().Be(Model.Dal.ErrorCodeEnum.Success);
            result.Token.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void AccountLoginUnit_WrongPass_Test()
        {
            var context = Context;
            var pass = Faker.StringFaker.AlphaNumeric(10);
            var user = new ApplicationUserEntity
            {
                Login = Faker.InternetFaker.Email(),
                PassHash = CryptoFacade.EncryptPass(pass)
            };

            context.Users.Add(user);

            context.SaveChanges();

            var reqLogin = new ReqLogin
            {
                Login = user.Login,
                Password = Faker.StringFaker.AlphaNumeric(10)
            };

            var result = _service.LoginAsync(reqLogin).Result;

            result.Should().NotBeNull();
            result.Error.Should().Be(Model.Dal.ErrorCodeEnum.LoginNotFound);
            result.Token.Should().BeNull();
        }

        [TestMethod]
        public void AccountLoginUnit_EmptyPass_Test()
        {
            var reqLogin = new ReqLogin
            {
                Login = Faker.InternetFaker.Email(),
            };

            var result = _service.LoginAsync(reqLogin).Result;

            result.Should().NotBeNull();
            result.Error.Should().Be(Model.Dal.ErrorCodeEnum.ArgumentMissingException);
            result.Token.Should().BeNull();
        }

        [TestMethod]
        public void AccountLoginUnit_EmptyLogin_Test()
        {
            var reqLogin = new ReqLogin
            {
                Password = Faker.InternetFaker.Email(),
            };

            var result = _service.LoginAsync(reqLogin).Result;

            result.Should().NotBeNull();
            result.Error.Should().Be(Model.Dal.ErrorCodeEnum.ArgumentMissingException);
            result.Token.Should().BeNull();
        }
    }
}
