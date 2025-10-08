namespace MusicQuiz.API.Dtos
{
    public record GameEntryDto(
        int Id,
        int CurrentRound,
        DateTime StartedAt,
        List<PlayerScoreEntryDto> PlayerScores);
}
