using Azure.Core;
using Azure.Core.Pipeline;
using DemoApp.ConsoleUI.Facades.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoApp.ConsoleUI.Facades
{
    /// <summary>
    /// Core injection facades
    /// </summary>
    internal class InjectionFacade
    {
        /// <summary>
        /// User secret file
        /// </summary>
        private const String FileName = "f2c53ce7-d7c8-44c0-bd11-1fb783b4e6dd";

        /// <summary>
        /// Settings objects
        /// </summary>
        private static UserSecretRoot Settings { get; set; } = new UserSecretRoot();

        /// <summary>
        /// Service provider
        /// </summary>
        public static ServiceProvider ServiceProvider { get; private set; }

        public static void ConfigureServiceProvider()
        {
            GetIConfigurationRoot();

            var services = new ServiceCollection();

            services.AddSingleton<AccountClient>(t => 
                                        new AccountClient(
                                            new ClientDiagnostics(ClientOptions.Default),
                                            new HttpPipeline(HttpClientTransport.Shared),
                                            new Uri(Settings.AppServerURI)));

            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Get configuration root
        /// </summary>
        /// <returns>Configuration root object</returns>
        private static IConfigurationRoot GetIConfigurationRoot()
        {
            var outputPath = Environment.CurrentDirectory;

            var configuration = new ConfigurationBuilder()
                //.AddJsonFile("appsettings.json", true)
                .AddUserSecrets(FileName)
               .Build();

            configuration.Bind(Settings);

            return configuration;
        }
    }
}
