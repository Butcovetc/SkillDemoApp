using DemoApp.Model.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
namespace Monee.Logic.DbLayer
{
    /// <summary>
    /// Database context
    /// </summary>
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        /// <summary>
        /// Database context
        /// </summary>
        public DataBaseContext(DbContextOptions<DataBaseContext> options) 
            : base(options) { }

#if DEBUG
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(x => Trace.WriteLine(x))
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
#endif

    }
}
