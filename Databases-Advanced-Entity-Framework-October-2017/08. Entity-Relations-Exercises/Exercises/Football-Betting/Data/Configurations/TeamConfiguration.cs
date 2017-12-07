namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasMany(t => t.HomeGames)
                .WithOne(hg => hg.HomeTeam)
                .HasForeignKey(t => t.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(t => t.AwayGames)
                .WithOne(ag => ag.AwayTeam)
                .HasForeignKey(t => t.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(t => t.PlayerId);
        }
    }
}