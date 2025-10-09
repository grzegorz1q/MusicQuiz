using MusicQuiz.API.Dtos;

namespace MusicQuiz.API.Services
{
    public interface IScoreboardService
    {
        Task<IEnumerable<ScoreboardDto>> GetScoreboardAsync();
    }
}
