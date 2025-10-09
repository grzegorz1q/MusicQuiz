using Microsoft.AspNetCore.Mvc;
using MusicQuiz.API.Services;

namespace MusicQuiz.API.Controllers
{
    [ApiController]
    [Route("scoreboard")]
    public class ScoreboardController : ControllerBase
    {
        private readonly IScoreboardService _scoreboardService;
        public ScoreboardController(IScoreboardService scoreboardService)
        {
            _scoreboardService = scoreboardService;
        }
        [HttpGet]
        public async Task<IActionResult> GetScoreboard()
        {
            try
            {
                var scoreboard = await _scoreboardService.GetScoreboardAsync();
                return Ok(scoreboard);
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
