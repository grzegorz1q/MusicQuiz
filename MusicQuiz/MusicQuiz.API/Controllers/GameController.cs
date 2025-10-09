using Microsoft.AspNetCore.Mvc;
using MusicQuiz.API.Services;

namespace MusicQuiz.API.Controllers
{
    [ApiController]
    [Route("games")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("{id}/state")]
        public async Task<IActionResult> GetGameState(int id)
        {
            try
            {
                var gameState = await _gameService.GetGameState(id);
                return Ok(gameState);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
