using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Services.Scoreboard.Application.Dtos;
using MusicQuiz.Services.Scoreboard.Infrastructure.Persistence;

namespace MusicQuiz.Services.Scoreboard.Application.CQRS.Queries
{
    public class GetScoreboardQueryHandler : IRequestHandler<GetScoreboardQuery, IEnumerable<ScoreboardDto>>
    {
        private readonly ScoreboardDbContext _context;
        public GetScoreboardQueryHandler(ScoreboardDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ScoreboardDto>> Handle(GetScoreboardQuery request, CancellationToken cancellationToken)
        {
            return await _context.PlayerScores
                .GroupBy(p => p.PlayerId)
                .Select(g => new ScoreboardDto(g.Key, g.Sum(x => x.Score), g.Select(x => x.GameId).Distinct().Count()))
                .ToListAsync(cancellationToken);
        }
    }
}
