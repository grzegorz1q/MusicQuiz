using MediatR;
using MusicQuiz.Services.Games.Infrastructure.Repositories;

namespace MusicQuiz.Services.Games.Application.CQRS.Commands.AddPoints
{
    public class AddPointsCommandHandler : IRequestHandler<AddPointsCommand>
    {
        private readonly IGameRepository _repository;
        public AddPointsCommandHandler(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(AddPointsCommand request, CancellationToken cancellationToken)
        {
            var game = await _repository.GetByIdAsync(request.GameId) ?? throw new KeyNotFoundException("Game not found");

            game.AddPoints(request.PlayerId, request.Points);

            await _repository.UpdateAsync(game);
        }
    }
}
