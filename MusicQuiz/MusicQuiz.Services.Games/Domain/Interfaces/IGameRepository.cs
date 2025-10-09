using MusicQuiz.Services.Games.Domain.Model;

namespace MusicQuiz.Services.Games.Domain.Interfaces
{
    public interface IGameRepository
    {
        Task<Game?> GetByIdAsync(int id);
        Task AddAsync(Game game);
        Task UpdateAsync(Game game);
        Task DeleteAsync(int id);
    }
}
