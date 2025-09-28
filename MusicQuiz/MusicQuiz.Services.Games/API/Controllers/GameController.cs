using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Services.Games.Application.Commands.CreateGame;

namespace MusicQuiz.Services.Games.API.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateGame(CreateGameCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
