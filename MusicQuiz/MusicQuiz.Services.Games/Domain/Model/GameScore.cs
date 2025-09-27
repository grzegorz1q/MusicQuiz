namespace MusicQuiz.Services.Games.Domain.Model
{
    public class GameScore
    {
        public int Id { get; set; }
        public int Score { get; private set; }
        public Game Game { get; set; } = default!;
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public GameScore(int gameId, int playerId)
        {
            GameId = gameId;
            PlayerId = playerId;
            Score = 0;
        }
        public void AddPoints(int value)
        {
            Score += value;
        }
    }
}
