namespace MusicQuiz.Services.Games.Application.Dtos
{
    public record GameDto(
        int Id, 
        string GameStatus, 
        int CurrentRound, 
        DateTime StartedAt, 
        DateTime? FinishedAt, 
        List<GameScoreDto> GameScores);
}
