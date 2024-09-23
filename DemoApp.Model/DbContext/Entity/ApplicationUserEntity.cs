using DemoApp.Model.DbContext.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.Model.DbContext.Entity
{
    /// <summary>
    /// Application user
    /// </summary>
    internal class ApplicationUserEntity : BaseIdEntity
    {
        /// <summary>
        /// User login
        /// </summary>
        public String? Login { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public String? Email { get; set; }

        /// <summary>
        /// Password hash
        /// </summary>
        public String? PassHash { get; set; }

        /// <summary>
        /// Used to kreate session
        /// </summary>
        public Guid SessionKeyUniq { get; set; }
    }
}
