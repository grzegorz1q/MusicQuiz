namespace MusicQuiz.Services.Games.Domain.Model
{
    public class PlayerScore
    {
        public int Score { get; set; } = 0;
        public int PlayerId { get; set; }
        public bool IsActive { get; set; } = true;
        public PlayerScore() { }
        public PlayerScore(int playerId)
        {
            PlayerId = playerId;
        }
        public void AddPoints(int value)
        {
            Score += value;
        }
    }
}
