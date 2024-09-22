using DemoApp.Model.DbContext.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.Model.DbContext.Entity
{
    /// <summary>
    /// Application user
    /// </summary>
    public class ApplicationUserEntity : BaseIdEntity
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
        /// Actual user session
        /// </summary>
        public String? Session { get; set; }
    }
}
