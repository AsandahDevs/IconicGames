namespace Games.Services.GameService;

public interface IGame {
   Task<List<Game>> GetGames();
   Task<Game?> GetGame(int id);
   Task<List<Game>?> PutGame(int id, Game game);
   Task<List<Game>> PostGame(Game game);
   Task<List<Game>?> DeleteGame(int id);
}