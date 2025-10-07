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

        [HttpGet("{id}/players")]
        public async Task<IActionResult> GetCurrentPlayers(int id)
        {
            try
            {
                var currentPlayers = await _gameService.GetCurrentPlayers(id);
                return Ok(currentPlayers);
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
