using MusicQuiz.Services.Games.Domain.Exceptions;

namespace MusicQuiz.Services.Games.Domain.Model
{
    public class Game
    {
        public int Id { get; set; }
        public GameStatus GameStatus { get; private set; } = GameStatus.InProgress;
        public int CurrentRound { get; private set; } = 1;
        public DateTime StartedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? FinishedAt { get; private set; }
        public List<GameScore> GameScores { get; private set; } = [];
        public void FinishGame()
        {
            if (GameStatus == GameStatus.Finished)
                throw new GameFinishedException("Game already finished!");
            GameStatus = GameStatus.Finished;
            FinishedAt = DateTime.UtcNow;
        }
        public void NextRound()
        {
            if(CurrentRound > 4)
                FinishGame();

            CurrentRound++;
        }

        public void AddPoints(int playerId, int points)
        {
            var score = GameScores.FirstOrDefault(s => s.PlayerId == playerId) ?? throw new PlayerNotInGameException("Player not in game");

            score.AddPoints(points);
        }

    }
}
