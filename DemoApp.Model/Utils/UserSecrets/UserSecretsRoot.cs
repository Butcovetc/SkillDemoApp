
using DemoApp.Model.Utils.UserSecrets;

namespace DemoApp.Model.Utils.UserSettings
{
    /// <summary>
    /// Stores user secrets setting 
    /// </summary>
    public class UserSecretsRoot
    {
        /// <summary>
        /// Connection strings
        /// </summary>
        public ConnectionStrings? ConnectionStrings { get; set; }

        /// <summary>
        /// Some app key values
        /// </summary>
        public String? SomeAppKey { get; set; }
    }
}
