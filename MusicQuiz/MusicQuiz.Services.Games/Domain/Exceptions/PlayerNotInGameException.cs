namespace MusicQuiz.Services.Games.Domain.Exceptions
{
    public class PlayerNotInGameException : Exception
    {
        public PlayerNotInGameException() { }
        public PlayerNotInGameException(string message) : base(message) { }
        public PlayerNotInGameException(string message, Exception innerException) : base(message, innerException) { }
    }
}
