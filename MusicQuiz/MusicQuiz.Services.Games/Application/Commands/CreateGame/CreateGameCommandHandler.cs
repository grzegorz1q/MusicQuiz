using MediatR;
using MusicQuiz.Services.Games.Domain.Model;
using MusicQuiz.Services.Games.Infrastructure.Repositories;

namespace MusicQuiz.Services.Games.Application.Commands.CreateGame
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, int>
    {
        private readonly IGameRepository _repository;
        public CreateGameCommandHandler(IGameRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            if (request.PlayerIds == null || request.PlayerIds.Count == 0)
                throw new ArgumentException("At least one player is required to create a game."); // change to custom exception ?

            var game = new Game();
            foreach(var playerId in request.PlayerIds)
            {
                game.GameScores.Add(new GameScore(game.Id, playerId));
            }
            await _repository.AddAsync(game);
            return game.Id;
        }
    }
}
