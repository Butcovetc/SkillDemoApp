using System.ComponentModel;
using System.Diagnostics;
using DemoApp.Model.Services;
using DemoApp.Model.Services.Interfaces;
using DemoApp.Model.Utils;
using DemoApp.Model.Utils.UserSettings;
using DemoApp.MSTests.Common.Mocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Monee.Logic.DbLayer;

namespace DemoApp.MSTests
{
    /// <summary>
    /// Base test class
    /// </summary>
    [TestClass]
    public class TestInitializerBase
    {

        /// <summary>
        /// Should be replaced if file name chadged
        /// </summary>
        private const String UserSecretFile = "a4173c1c-b17e-4f51-96ae-67c24dc7a624";

        /// <summary>
        /// Service provider field
        /// </summary>
        protected ServiceProvider? ServiceProvider { get; private set; }

        /// <summary>
        /// Configuration root object
        /// </summary>
        protected static IConfiguration? Configuration { get; private set; }

        /// <summary>
        /// User settings
        /// </summary>
        protected static UserSecretsRoot Settings { get; private set; }  = new UserSecretsRoot();

        /// <summary>
        /// Test initial actions
        /// </summary>
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            Configuration = GetIConfigurationRoot();

            //no encryption without salt
            if (Settings == null || String.IsNullOrEmpty(Settings.UserPassWordEncryptionSalt))
                throw new InvalidEnumArgumentException(nameof(Settings.UserPassWordEncryptionSalt));

            CryptoFacade.SetSalt(Settings.UserPassWordEncryptionSalt);
        }

        /// <summary>
        /// Initializing logging
        /// </summary>
        public static void InitializeLogging()
        {
            AppDomain.CurrentDomain.FirstChanceException += (source, e) =>
            {
                if (e.Exception is AssertFailedException == false)
                {
                    Trace.WriteLine(e.Exception.GetType().ToString());
                    Trace.WriteLine(e.Exception.Message.ToString());

                    if (e.Exception.InnerException != null)
                    {
                        Trace.WriteLine(e.Exception.InnerException.GetType().ToString());
                        Trace.WriteLine(e.Exception.InnerException.Message.ToString());
                    }
                }
            };
        }
        protected void ConfigureServieProvider()
        {
            var services = new ServiceCollection();

            // Using In-Memory database for testing
            services.AddDbContext<DataBaseContext>(options =>
                options.UseInMemoryDatabase("TestDb"));


            services.AddSingleton<IAccountService,AccountService>();
            services.AddSingleton<ILogger,TraceLogger>();

            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Get configuration root
        /// </summary>
        /// <returns>Configuration root object</returns>
        public static IConfigurationRoot GetIConfigurationRoot()
        {
            var outputPath = Environment.CurrentDirectory;

            var configuration = new ConfigurationBuilder()
                //.AddJsonFile("appsettings.json", true)
                .AddUserSecrets(UserSecretFile)
               .Build();

            configuration.Bind(Settings);

            return configuration;
        }
    }
}
