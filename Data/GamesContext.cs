using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Games.Data;

public class GamesContext : IdentityDbContext<IdentityUser>
{
    public GamesContext(DbContextOptions<GamesContext> options): base(options)
    {
    }
    public DbSet<Game> Game { get; set; } = null!;
    public DbSet<Publisher> Publisher {get;set;} = null!;
}