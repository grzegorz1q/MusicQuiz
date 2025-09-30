using MassTransit;
using MusicQuiz.Messages.Commands.Games;
using MusicQuiz.Services.Scoreboard.Domain.Interfaces;
using MusicQuiz.Services.Scoreboard.Domain.Model;

namespace MusicQuiz.Services.Scoreboard.Application.Integration.Consumers
{
    public class AwardPointsConsumer : IConsumer<AwardPoints>
    {
        private readonly IPlayerScoreRepository _repository;
        public AwardPointsConsumer(IPlayerScoreRepository repository)
        {
            _repository = repository;
        }
        public async Task Consume(ConsumeContext<AwardPoints> context)
        {
            var playerScore = new PlayerScore(context.Message.GameId, context.Message.PlayerId, context.Message.Score);
            await _repository.AddAsync(playerScore);
        }
    }
}
