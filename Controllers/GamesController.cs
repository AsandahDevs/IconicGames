using Microsoft.AspNetCore.Mvc;
﻿using Microsoft.AspNetCore.Http;
using Games.Services.GameService;

namespace Games.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGame _gameService;

        public GamesController(IGame gameService)
        {
            _gameService = gameService;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
           return await _gameService.GetGames();
        }

        // GET: api/Games/5
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

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
           var result = await _gameService.PutGame(id,game);
           if(result is null){
            return NotFound();
           }else{
            return Ok(result);
           }
        }

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            await _gameService.PostGame(game);
            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
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
