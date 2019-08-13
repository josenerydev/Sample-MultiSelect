using Sample_MultiSelect.Data.Configurations;
using Sample_MultiSelect.Data.Models;
using System.Data.Entity;

namespace Sample_MultiSelect.Data.DbContexts
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("name=AppContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppContext, Sample_MultiSelect.Data.Migrations.Configuration>());
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PlayerEntityConfiguration());
            modelBuilder.Configurations.Add(new TeamEntityConfiguration());
        }
    }
}
