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
        public async Task<ActionResult<List<Game>>> GetGames()
        {
           return await _gameService.GetGames();
        }

        // GET: Games/5
        /// <summary>
        /// Retrieves a single game
        /// </summary>
        /// <returns> A game.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
           var game = await _gameService.GetGame(id);

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
        public async Task<IActionResult> UpdateGame(int id, Game game)
        {
           var result = await _gameService.PutGame(id,game);
           if(result is null){
            return NotFound();
           }else{
            return Ok(result);
           }
        }

        // POST: Games/AddGame
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Adds a new game to a database
        /// </summary>
        /// <returns> A list of games added to a database.</returns>
        [HttpPost("AddGame")]
        public async Task<ActionResult<Game>> AddGame(Game game)
        {
            await _gameService.PostGame(game);
            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        // DELETE: Games/Delete/5
        /// <summary>
        /// Removes a game from database records
        /// </summary>
        /// <returns> List of games that still exist on the database.</returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
           var result = await _gameService.DeleteGame(id);
           if(result is null){
            return NotFound();
           }else{
            return Ok(result);
           }
        }
    }
}
