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
      var games = _context.Game
     .Include(game => game.Publisher)
     .Select(game => new GameDto   //TODO: implement AutoMapper
     {
        Id = game.Id,
        GameTitle = game.GameTitle,
        ReleaseYear = game.ReleaseYear,
        Developers = game.Developers,
        Revenue = game.Revenue,
        PublisherName = game.Publisher.Name
     });
      return games;
   }

   public GameDto? GetGame(int id)
   {
      var games = _context.Game
      .Include(game => game.Publisher)
      .Select(game => new GameDto      //TODO: implement AutoMapper
      {
         Id = game.Id,
         GameTitle = game.GameTitle,
         ReleaseYear = game.ReleaseYear,
         Developers = game.Developers,
         Revenue = game.Revenue,
         PublisherName = game.Publisher.Name
      });
      var individualGame = games.FirstOrDefault(game => game.Id == id);
      if (individualGame == null)
      {
         return null;
      }
      return individualGame;
   }

   public IQueryable<GameDto> PostGame(GameDto game)
   {
      var publisher = _context.Publisher.FirstOrDefault(p => p.Name == game.PublisherName);
      if (publisher == null)
      {
         publisher = new Publisher { Name = game.PublisherName };
         _context.Publisher.Add(publisher); // Adding a new publisher to publisher table , if they don't exist.
      }

      var newGame = new Game //TODO: implement AutoMapper
      {
         Id = game.Id,
         GameTitle = game.GameTitle,
         ReleaseYear = game.ReleaseYear,
         Developers = game.Developers,
         Revenue = game.Revenue,
         Publisher = publisher
      };

      _context.Game.Add(newGame);
      _context.SaveChanges();

      // Return the updated list of games
      return GetGames();
   }


   public IQueryable<GameDto>? PutGame(int id, GameDto game)
   {
      var gameToUpdate = _context.Game.FirstOrDefault(g => g.Id == id);
      var publisher = _context.Publisher.FirstOrDefault(p => p.Name == game.PublisherName);
      if (gameToUpdate != null && publisher != null)
      {
         // Update properties
         gameToUpdate.GameTitle = game.GameTitle;
         gameToUpdate.ReleaseYear = game.ReleaseYear;
         gameToUpdate.Developers = game.Developers;
         gameToUpdate.Revenue = game.Revenue;
         gameToUpdate.Publisher = publisher;

         // Mark as modified
         _context.Entry(gameToUpdate).State = EntityState.Modified;

         _context.SaveChanges();

         return GetGames();
      }
      
      return null;

   }

}