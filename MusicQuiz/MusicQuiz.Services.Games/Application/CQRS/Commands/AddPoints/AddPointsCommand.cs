using MediatR;

namespace MusicQuiz.Services.Games.Application.CQRS.Commands.AddPoints
{
    public record AddPointsCommand(int GameId, int PlayerId, int Points) : IRequest;
}
