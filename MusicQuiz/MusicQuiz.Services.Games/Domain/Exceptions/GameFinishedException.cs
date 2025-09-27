namespace MusicQuiz.Services.Games.Domain.Exceptions
{
    public class GameFinishedException : Exception
    {
        public GameFinishedException() { }
        public GameFinishedException(string message) : base(message) { }
        public GameFinishedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
