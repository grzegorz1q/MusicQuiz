namespace MusicQuiz.Messages.Commands.Games
{
    public record AwardPoints(int GameId, int PlayerId, int Score);
}
