using MusicQuiz.Services.Scoreboard.Domain.Model;

namespace MusicQuiz.Services.Scoreboard.Domain.Interfaces
{
    public interface IPlayerScoreRepository
    {
        Task<PlayerScore?> GetByIdAsync(int id);
        Task AddAsync(PlayerScore playerScore);
        Task UpdateAsync(PlayerScore playerScore);
    }
}
