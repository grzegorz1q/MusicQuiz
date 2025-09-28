using MediatR;

namespace MusicQuiz.Services.Games.Application.Commands.CreateGame
{
    public record CreateGameCommand(List<int> PlayerIds) : IRequest<int>;
}
