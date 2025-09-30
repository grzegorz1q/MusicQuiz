namespace MusicQuiz.Services.Games.Domain.Model
{
    public class GameScore
    {
        public int Score { get; set; }
        public int PlayerId { get; set; }
        public GameScore() { }
        public GameScore(int playerId)
        {
            PlayerId = playerId;
            Score = 0;
        }
        public void AddPoints(int value)
        {
            Score += value;
        }
    }
}
