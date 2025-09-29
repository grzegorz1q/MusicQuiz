using MediatR;
using MusicQuiz.Services.Games.Application.Dtos;

namespace MusicQuiz.Services.Games.Application.CQRS.Queries
{
    public record GetGameQuery(int Id) : IRequest<GameDto>;
}
