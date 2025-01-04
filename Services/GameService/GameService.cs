using Microsoft.EntityFrameworkCore;

namespace Games.Services.GameService;
public class GameService : IGame  {
    private readonly GamesContext _context;

    public GameService(GamesContext context){
            _context = context;
        }

    public async Task<List<Game>?> DeleteGame(int id)
    {
         var game = await _context.Game.FindAsync(id);
         if(game is null){
            return null;
         }
        _context.Game.Remove(game);
        await _context.SaveChangesAsync();
        return await _context.Game.ToListAsync();
    }

    public async Task<List<Game>> GetGames()
    {
       return await _context.Game.ToListAsync();
    }

    public async Task<Game?> GetGame(int id)
    {
         var game = await _context.Game.FindAsync(id);
         if(game is null){
            return null;
         }
         return game;
    }

    public async Task<List<Game>> PostGame(Game game)
    {
          _context.Game.Add(game);
        await _context.SaveChangesAsync();
        return await _context.Game.ToListAsync();
    }

    public async Task<List<Game>?> PutGame(int id, Game game)
    {
       var gameExists = _context.Game.Any(e => e.Id == id);
       if(gameExists){
        _context.Entry(game).State = EntityState.Modified;
          await _context.SaveChangesAsync();
          return await _context.Game.ToListAsync();
       }else{
        return null;
       }
      
    } 
}