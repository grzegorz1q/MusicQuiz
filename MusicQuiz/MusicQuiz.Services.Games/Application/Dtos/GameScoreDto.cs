using MusicQuiz.Services.Games.Domain.Model;

namespace MusicQuiz.Services.Games.Application.Dtos
{
    public record GameScoreDto(int Id, int Score, int GameId, int PlayerId);
}
