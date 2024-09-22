using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.Model.DbContext.Entity.Base
{
    /// <summary>
    /// Base class for entities with int id Identity - ON
    /// </summary>
    public abstract class BaseIdEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}