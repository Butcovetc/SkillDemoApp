using DemoApp.Model.Dal.Requests;
using DemoApp.Model.Services;
using DemoApp.Model.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace DemoApp.MSTests.Account
{
    [TestClass]
    public class AccountLoginUnit_Tests : TestInitializerBase
    {
        IAccountService _service;
        ILogger<AccountService> _logger;
        private IServiceScope _scope;


        [ClassInitialize]
        public void ClassInitializeMethod()
        {
            ConfigureServieProvider();

            _scope = base.ServiceProvider.CreateScope();

            _logger = Mock.Of<ILogger<AccountService>>();
            _service = _scope.ServiceProvider.GetRequiredService<IAccountService>();
        }

        [TestInitialize]
        public void TestInitializeMethod()
        {
            
        }

        [TestCleanup]
        public void TestCleanupMethod()
        {
            if (_scope == null)
                _scope.Dispose();
        }


        [TestMethod]
        public void AccountLoginUnit_Success_Test()
        {
            var reqLogin = new ReqLogin
            {
                Login = "acount@gmail.com",
                Password = "password"
            };

            var result = _service.LoginAsync(reqLogin);  
        }
    }
}
