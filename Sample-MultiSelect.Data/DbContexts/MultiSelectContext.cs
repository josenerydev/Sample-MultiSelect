using Sample_MultiSelect.Data.Configurations;
using Sample_MultiSelect.Data.Models;
using System.Data.Entity;

namespace Sample_MultiSelect.Data.DbContexts
{
    public class MultiSelectContext : DbContext
    {
        public MultiSelectContext()
            : base("name=MultiSelectContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MultiSelectContext, Sample_MultiSelect.Data.Migrations.Configuration>());
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
