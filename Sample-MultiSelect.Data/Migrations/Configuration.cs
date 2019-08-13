using System.Data.Entity.Migrations;

namespace Sample_MultiSelect.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Sample_MultiSelect.Data.DbContexts.MultiSelectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Sample_MultiSelect.Data.DbContexts.MultiSelectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
