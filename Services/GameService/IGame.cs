
namespace Games.Services.GameService;

public interface IGame
{
   Task<IQueryable<GameDto>> GetGames();
   Task<GameDto?> GetGame(int id);
   Task<PublisherDto?> GetPublisher(int id);
   Task<IQueryable<GameDto>?> PutGame(int id, GameDto game);
   Task<IQueryable<GameDto>> PostGame(GameDto game);
   Task<IQueryable<GameDto>?> DeleteGame(int id);
}