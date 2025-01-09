using Microsoft.EntityFrameworkCore;

namespace Games.Data;

public class GamesContext : DbContext
{
    public GamesContext(DbContextOptions<GamesContext> options): base(options)
    {
    }
    public DbSet<Game> Game { get; set; } = null!;

    public DbSet<Publisher> Publisher {get;set;} = null!;
}