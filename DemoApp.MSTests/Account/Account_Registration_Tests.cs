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
    public class Account_Registration_Tests : TestInitializerBase
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
        public void AccountRegister_Success_Test()
        {
            var reqLogin = new ReqRegister
            {
                Login = Faker.StringFaker.AlphaNumeric(10),
                Email = Faker.InternetFaker.Email(),
                Password = Faker.StringFaker.AlphaNumeric(10)
            };

            var result = _service.Register(reqLogin).Result;  

            result.Should().NotBeNull();
            result.Error.Should().Be(Model.Dal.ErrorCodeEnum.Success);
            result.Id.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void AccountRegister_EmptyLogin_Test()
        {
            var reqLogin = new ReqRegister
            {
                //Login = Faker.StringFaker.AlphaNumeric(10),
                Email = Faker.InternetFaker.Email(),
                Password = Faker.StringFaker.AlphaNumeric(10)
            };

            var result = _service.Register(reqLogin).Result;

            result.Should().NotBeNull();
            result.Error.Should().Be(Model.Dal.ErrorCodeEnum.ArgumentMissingException);
            result.Id.Should().Be(0);
        }

        [TestMethod]
        public void AccountRegister_EmptyPass_Test()
        {
            var reqLogin = new ReqRegister
            {
                Login = Faker.StringFaker.AlphaNumeric(10),
                Email = Faker.InternetFaker.Email(),
                //Password = Faker.StringFaker.AlphaNumeric(10)
            };

            var result = _service.Register(reqLogin).Result;

            result.Should().NotBeNull();
            result.Error.Should().Be(Model.Dal.ErrorCodeEnum.ArgumentMissingException);
            result.Id.Should().Be(0);
        }

        [TestMethod]
        public void AccountRegister_EmptyEmail_Test()
        {
            var reqLogin = new ReqRegister
            {
                Login = Faker.StringFaker.AlphaNumeric(10),
                //Email = Faker.InternetFaker.Email(),
                Password = Faker.StringFaker.AlphaNumeric(10)
            };

            var result = _service.Register(reqLogin).Result;

            result.Should().NotBeNull();
            result.Error.Should().Be(Model.Dal.ErrorCodeEnum.ArgumentMissingException);
            result.Id.Should().Be(0);
        }
    }
}
