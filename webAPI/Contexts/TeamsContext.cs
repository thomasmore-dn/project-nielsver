using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Contexts
{
  public class TeamsContext : DbContext
{
    public TeamsContext(DbContextOptions<TeamsContext> options) : base(options)
    {
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedTeams(modelBuilder);
        SeedPlayers(modelBuilder);
    }

    private void SeedTeams(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>().HasData(
            new Team { TeamId = 1, TeamName = "BC Oostende", Wins = 5, Losses = 5 },
            new Team { TeamId = 2, TeamName = "Kangoeroes Mechelen", Wins = 8, Losses = 2 },
            new Team { TeamId = 3, TeamName = "Circus Brussel", Wins = 7, Losses = 3 }
        );
    }

    private void SeedPlayers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().HasData(
            new Player { PlayerId = -1, Name = "Thibaut tsjienda baloji", TotalPoints = 100, GamesPlayed = 10, Position = "Center", TeamId = 1 },
            new Player { PlayerId = -2, Name = "Sam Van Rossom", TotalPoints = 80, GamesPlayed = 10, Position = "Guard", TeamId = 1 },
            new Player { PlayerId = -3, Name = "Andrej Cuyvers", TotalPoints = 90, GamesPlayed = 10, Position = "Forward", TeamId = 2 },
            new Player { PlayerId = -4, Name = "Godwin thimanga", TotalPoints = 95, GamesPlayed = 10, Position = "Forward", TeamId = 3 }
        );
    }
}

}