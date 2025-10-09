using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Services.Scoreboard.Application.CQRS.Queries;

namespace MusicQuiz.Services.Scoreboard.API.Controllers
{
    [ApiController]
    [Route("api/scoreboard")]
    public class ScoreboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ScoreboardController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetLeaderboard()
        {
            var result = await _mediator.Send(new GetScoreboardQuery());
            return Ok(result);
        }
    }
}
