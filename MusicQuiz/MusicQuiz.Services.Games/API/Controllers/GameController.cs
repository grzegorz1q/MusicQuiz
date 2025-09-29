using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Services.Games.Application.CQRS.Commands.AddPoints;
using MusicQuiz.Services.Games.Application.CQRS.Commands.CreateGame;
using MusicQuiz.Services.Games.Application.CQRS.Commands.FinishGame;
using MusicQuiz.Services.Games.Application.CQRS.Queries;
using MusicQuiz.Services.Games.Application.Dtos;
using MusicQuiz.Services.Games.Domain.Exceptions;

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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            try
            {
                var game = await _mediator.Send(new GetGameQuery(id));
                return Ok(game);
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
        [HttpPatch("{id}/points")]
        public async Task<IActionResult> AddPoints(int id, AddPointsDto dto)
        {
            try
            {
                await _mediator.Send(new AddPointsCommand(id, dto.PlayerId, dto.Points));
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(PlayerNotInGameException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("{id}/finish")]
        public async Task<IActionResult> FinishGame(int id)
        {
            try
            {
                await _mediator.Send(new FinishGameCommand(id));
                return Ok();
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
