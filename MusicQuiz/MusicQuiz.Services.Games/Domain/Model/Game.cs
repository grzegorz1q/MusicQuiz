using MusicQuiz.Services.Games.Domain.Exceptions;

namespace MusicQuiz.Services.Games.Domain.Model
{
    public class Game
    {
        public int Id { get; set; }
        public int CurrentRound { get; set; } = 1;
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public List<GameScore> GameScores { get; set; } = [];
        public void NextRound()
        {
            CurrentRound++;
        }

        public void AddPoints(int playerId, int points)
        {
            var score = GameScores.FirstOrDefault(s => s.PlayerId == playerId) ?? throw new PlayerNotInGameException("Player not in game");

            score.AddPoints(points);
        }
    }
}
