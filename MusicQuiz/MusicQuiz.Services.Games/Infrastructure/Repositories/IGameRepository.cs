using MusicQuiz.Services.Games.Domain.Model;

namespace MusicQuiz.Services.Games.Infrastructure.Repositories
{
    public interface IGameRepository
    {
        Task<Game?> GetByIdAsync(int id);
        Task AddAsync(Game game);
        Task UpdateAsync(Game game);
    }
}
