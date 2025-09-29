using MassTransit;
using MediatR;
using MusicQuiz.Services.Games.Application.Integration.Commands;
using MusicQuiz.Services.Games.Infrastructure.Repositories;

namespace MusicQuiz.Services.Games.Application.CQRS.Commands.FinishGame
{
    public class FinishGameCommandHandler : IRequestHandler<FinishGameCommand>
    {
        private readonly IGameRepository _repository;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        public FinishGameCommandHandler(IGameRepository repository, ISendEndpointProvider sendEndpointProvider)
        {
            _repository = repository;
            _sendEndpointProvider = sendEndpointProvider;
        }
        public async Task Handle(FinishGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _repository.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Game not found");
            game.FinishGame();

            await _repository.UpdateAsync(game);

            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:award-points"));
            foreach (var result in game.GameScores)
            {
                await endpoint.Send(new AwardPoints(result.GameId, result.PlayerId, result.Score), cancellationToken);
            }
        }
    }
}
