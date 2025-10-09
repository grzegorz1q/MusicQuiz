using MassTransit;
using MediatR;
using MusicQuiz.Messages.Commands.Games;
using MusicQuiz.Services.Games.Domain.Interfaces;

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

            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:award-points"));
            foreach (var result in game.PlayerScores)
            {
                await endpoint.Send(new AwardPoints(game.Id, result.PlayerId, result.Score), cancellationToken);
            }
            await _repository.DeleteAsync(game.Id);
        }
    }
}
