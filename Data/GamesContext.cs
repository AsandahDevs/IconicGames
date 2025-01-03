using Microsoft.EntityFrameworkCore;

namespace Games.Data;

public class GamesContext : DbContext
{
    public GamesContext(DbContextOptions<GamesContext> options): base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=p@$$w*rd;Database=Gamesdb");;
    }
    public DbSet<Game> Game { get; set; } = null!;
}