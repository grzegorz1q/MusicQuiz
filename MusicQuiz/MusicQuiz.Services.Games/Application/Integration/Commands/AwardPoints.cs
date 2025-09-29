namespace MusicQuiz.Services.Games.Application.Integration.Commands
{
    public record AwardPoints(int GameId, int PlayerId, int Score);
}
