using Sample_MultiSelect.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Sample_MultiSelect.Data.Configurations
{
    public class TeamEntityConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamEntityConfiguration()
        {
            ToTable("Team");

            HasKey(t => t.Id);

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            Property(t => t.Name)
                .HasMaxLength(128)
                .IsRequired();

            HasMany(t => t.Players)
                .WithMany(p => p.Teams)
                .Map(tp =>
                {
                    tp.MapLeftKey("PlayerId");
                    tp.MapRightKey("TeamId");
                    tp.ToTable("PlayerTeam");
                });
        }
    }
}
