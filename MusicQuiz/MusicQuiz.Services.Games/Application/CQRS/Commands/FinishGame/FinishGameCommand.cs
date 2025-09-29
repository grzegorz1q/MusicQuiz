using MediatR;

namespace MusicQuiz.Services.Games.Application.CQRS.Commands.FinishGame
{
    public record FinishGameCommand(int Id) : IRequest;
}
