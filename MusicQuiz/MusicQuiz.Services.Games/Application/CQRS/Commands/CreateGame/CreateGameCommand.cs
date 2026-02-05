using MediatR;
using MusicQuiz.Services.Games.Application.Dtos;

namespace MusicQuiz.Services.Games.Application.CQRS.Commands.CreateGame
{
    public record CreateGameCommand(List<int> PlayerIds) : IRequest<GameDto>;
}
