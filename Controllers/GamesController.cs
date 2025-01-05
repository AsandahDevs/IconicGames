using Microsoft.AspNetCore.Mvc;
using Games.Services.GameService;

namespace Games.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGame _gameService;
        public GamesController(IGame gameService)
        {
            _gameService = gameService;
        }

        // GET: Games
        /// <summary>
        /// Retrieves a list of games
        /// </summary>
        /// <returns> A list of games.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<GameDto>))]
        public ActionResult<IQueryable<GameDto>> GetGames()
        {
            var games = _gameService.GetGames();
            return Ok(games);
        }

        // GET: Games/5
        /// <summary>
        /// Retrieves a single game
        /// </summary>
        /// <returns> A game.</returns>
        [HttpGet("{id}")]
        public ActionResult<GameDto> GetGame(int id)
        {
            var game = _gameService.GetGame(id);

            if (game == null)
            {
                return NotFound();
            }
            return game;
        }

        // PUT: Games/UpdateGame/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates the specified game
        /// </summary>
        /// <returns> A Updated list of Games.</returns>
        [HttpPut("UpdateGame/{id}")]
        public ActionResult<IQueryable<GameDto>> UpdateGame(int id, GameDto game)
        {
            var result = _gameService.PutGame(id, game);
            if (result is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        // POST: Games/AddGame
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Adds a new game to a database
        /// </summary>
        /// <returns> A new list of games added to a database.</returns>
        [HttpPost("AddGame")]
        public ActionResult<IQueryable<GameDto>> AddGame(GameDto game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newGame = _gameService.PostGame(game);
            return CreatedAtAction("GetGame", new { id = game.Id }, newGame);
        }

        // DELETE: Games/Delete/5
        /// <summary>
        /// Removes a game from database records
        /// </summary>
        /// <returns> Current list of games.</returns>
        [HttpDelete("Delete/{id}")]
        public ActionResult<IQueryable<GameDto>> DeleteGame(int id)
        {
            var result = _gameService.DeleteGame(id);
            if (result is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
