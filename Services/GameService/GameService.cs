using Microsoft.EntityFrameworkCore;

namespace Games.Services.GameService;
public class GameService : IGame
{
   private readonly GamesContext _context;

   public GameService(GamesContext context)
   {
      _context = context;
   }

   public IQueryable<GameDto>? DeleteGame(int id)
   {
      var game = _context.Game.Find(id);
      if (game is null)
      {
         return null;
      }
      _context.Game.Remove(game);
      _context.SaveChangesAsync();
      return GetGames();
   }

   public IQueryable<GameDto> GetGames()
   {
      var games = from game in _context.Game
                  join publisher in _context.Publisher on game.PublisherId equals publisher.Id
                  select new GameDto
                  {
                     Id = game.Id,
                     GameTitle = game.GameTitle,
                     ReleaseYear = game.ReleaseYear,
                     Developers = game.Developers,
                     PublisherName = publisher.Name,
                     Revenue = game.Revenue
                  };

      return games;

   }

   public GameDto? GetGame(int id)
   {
      var game = _context.Game.Include(game => game.Publisher).Select(game => new GameDto
      {
         Id = game.Id,
         GameTitle = game.GameTitle,
         ReleaseYear = game.ReleaseYear,
         Developers = game.Developers,
         PublisherName = game.Publisher.Name,
         Revenue = game.Revenue
      }).SingleOrDefault(game => game.Id == id);
      if (game == null)
      {
         return null;
      }
      return game;
   }

   public IQueryable<GameDto> PostGame(GameDto game)
   {
      var publisher = _context.Publisher.FirstOrDefault(p => p.Name == game.PublisherName);
      if (publisher == null)
      {
         publisher = new Publisher { Name = game.PublisherName };
         _context.Publisher.Add(publisher); // Adding a new publisher to publisher table , if they don't exist.
      }

      var newGame = new Game
      {
         Id = game.Id,
         GameTitle = game.GameTitle,
         ReleaseYear = game.ReleaseYear,
         Developers = game.Developers,
         Publisher = publisher,
         Revenue = game.Revenue
      };

      _context.Game.Add(newGame);
      _context.SaveChanges();

      // Return the updated list of games
      return GetGames();
   }


   public IQueryable<GameDto>? PutGame(int id, GameDto game)
   {
      var gameExists = _context.Game.Any(g => g.Id == id);
      if (gameExists)
      {
         _context.Entry(game).State = EntityState.Modified;
         _context.SaveChanges();
         return GetGames();
      }
      else
      {
         return null;
      }

   }
}