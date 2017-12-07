namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasMany(g => g.PlayerStatistics)
                .WithOne(ps => ps.Game)
                .HasForeignKey(g => g.GameId);
            builder.HasMany(g => g.Bets)
                .WithOne(b => b.Game)
                .HasForeignKey(g => g.BetId);
        }
    }
}