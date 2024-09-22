using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Model.DbContext.Entity.Base
{
    /// <summary>
    /// Removable entity base class
    /// </summary>
    public abstract class RemovableEntity:BaseIdEntity
    {
        /// <summary>
        /// True if object removed
        /// </summary>
        public Boolean Removed { get; set; }
    }
}
