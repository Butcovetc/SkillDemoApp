using System.ComponentModel;
using System.Diagnostics;
using DemoApp.Model.Utils;
using DemoApp.Model.Utils.UserSettings;
using Microsoft.Extensions.Configuration;

namespace DemoApp.MSTests
{
    /// <summary>
    /// Base test class
    /// </summary>
    [TestClass]
    public class TestInitializerBase
    {
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

        /// <summary>
        /// Get configuration root
        /// </summary>
        /// <returns>Configuration root object</returns>
        public static IConfigurationRoot GetIConfigurationRoot()
        {
            var outputPath = Environment.CurrentDirectory;

            var configuration = new ConfigurationBuilder()
                //.AddJsonFile("appsettings.json", true)
                .AddUserSecrets("a4173c1c-b17e-4f51-96ae-67c24dc7a624")
               .Build();

            configuration.Bind(Settings);

            return configuration;
        }
    }
}
