using DemoApp.Model.DbContext;
using DemoApp.Model.DbContext.Entity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
namespace Monee.Logic.DbLayer
{
    /// <summary>
    /// Database context
    /// </summary>
    internal class DataBaseContext : DbContext
    {
        /// <summary>
        /// Database context. Used in mock's
        /// </summary>
        public DataBaseContext()
            : base() { }

        /// <summary>
        /// Database context
        /// </summary>
        public DataBaseContext(DbContextOptions<DataBaseContext> options) 
            : base(options) { }

        /// <summary>
        /// Application users
        /// </summary>
        public DbSet<ApplicationUserEntity> Users { get; set; }


#if DEBUG
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(x => Trace.WriteLine(x))
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
#endif


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<ApplicationUserEntity>()
                .HasIndex(account => account.Login)
                .IsUnique();
        }
    }
}
