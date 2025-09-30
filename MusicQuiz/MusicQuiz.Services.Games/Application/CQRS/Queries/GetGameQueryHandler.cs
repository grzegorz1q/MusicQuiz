using MediatR;
using MusicQuiz.Services.Games.Application.Dtos;
using MusicQuiz.Services.Games.Domain.Interfaces;

namespace MusicQuiz.Services.Games.Application.CQRS.Queries
{
    public class GetGameQueryHandler : IRequestHandler<GetGameQuery, GameDto>
    {
        private readonly IGameRepository _repository;
        public GetGameQueryHandler(IGameRepository repository)
        {
            _repository = repository;
        }
        public async Task<GameDto> Handle(GetGameQuery request, CancellationToken cancellationToken)
        {
            var game = await _repository.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Game not found");
            var gameDto = new GameDto(
                game.Id,
                game.CurrentRound,
                game.StartedAt,
                game.GameScores.Select(gs => new GameScoreDto(
                    gs.Score,
                    gs.PlayerId)
                ).ToList()
            );
            return gameDto;
        }
    }
}
