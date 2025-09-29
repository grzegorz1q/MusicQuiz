namespace MusicQuiz.Services.Scoreboard.Domain.Model
{
    public class PlayerScore
    {
        public int Id {  get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int Score { get; set; }
        public DateTime RecordedAt { get; private set; } = DateTime.UtcNow;
        public void SetScoreForPlayerInGame(int gameId, int playerId, int points)
        {
            GameId = gameId;
            PlayerId = playerId;
            Score = points;
        }
    }
}
