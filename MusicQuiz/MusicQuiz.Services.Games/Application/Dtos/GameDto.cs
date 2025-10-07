namespace MusicQuiz.Services.Games.Application.Dtos
{
    public record GameDto(
        int Id, 
        int CurrentRound, 
        DateTime StartedAt, 
        List<PlayerScoreDto> PlayerScores);
}
