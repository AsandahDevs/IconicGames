
namespace Games.Services.GameService;

public interface IGame
{
   IQueryable<GameDto>? GetGames();
   GameDto? GetGame(int id);
   IQueryable<GameDto>? PutGame(int id, GameDto game);
   IQueryable<GameDto> PostGame(GameDto game);
   IQueryable<GameDto>? DeleteGame(int id);
}