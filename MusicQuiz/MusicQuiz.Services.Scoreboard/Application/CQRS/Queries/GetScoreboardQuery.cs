using MediatR;
using MusicQuiz.Services.Scoreboard.Application.Dtos;

namespace MusicQuiz.Services.Scoreboard.Application.CQRS.Queries
{
    public record GetScoreboardQuery() : IRequest<IEnumerable<ScoreboardDto>>;
}
