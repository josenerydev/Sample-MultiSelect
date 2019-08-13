using Sample_MultiSelect.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Sample_MultiSelect.Data.Configurations
{
    public class PlayerEntityConfiguration : EntityTypeConfiguration<Player>
    {
        public PlayerEntityConfiguration()
        {
            ToTable("Player");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            Property(x => x.Name)
                .HasMaxLength(128)
                .IsRequired();

            HasMany(p => p.Teams)
                .WithMany(t => t.Players)
                .Map(pt =>
                {
                    pt.MapLeftKey("PlayerId");
                    pt.MapRightKey("TeamId");
                    pt.ToTable("PlayerTeam");
                });
        }
    }
}
