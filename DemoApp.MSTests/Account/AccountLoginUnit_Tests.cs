using DemoApp.Model.Dal.Requests;
using DemoApp.Model.DbContext;
using DemoApp.Model.DbContext.Entity;
using DemoApp.Model.Services;
using DemoApp.Model.Services.Interfaces;
using DemoApp.Model.Utils;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Monee.Logic.DbLayer;
using Moq;
using System.Reflection.Metadata;
using System.Security.AccessControl;

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
            var user = new ApplicationUserEntity
            {
                Email = Faker.InternetFaker.Email(),
                PassHash = CryptoFacade.EncryptPass(Faker.StringFaker.AlphaNumeric(10))
            };

            context.Users.Add(user);

            context.SaveChanges();

            var reqLogin = new ReqLogin
            {
                Login = "acount@gmail.com",
                Password = "password"
            };

            var result = _service.LoginAsync(reqLogin).Result;  

            result.Should().NotBeNull();
            result.Error.Should().Be(Model.Dal.ErrorCodeEnum.Success);
        }
    }
}
