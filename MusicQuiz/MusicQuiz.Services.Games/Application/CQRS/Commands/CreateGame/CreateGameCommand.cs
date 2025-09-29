using MediatR;

namespace MusicQuiz.Services.Games.Application.CQRS.Commands.CreateGame
{
    public record CreateGameCommand(List<int> PlayerIds) : IRequest<int>;
}
