using MusicQuiz.Services.Quiz.Domain.Model;

namespace MusicQuiz.Services.Quiz.Domain.Interfaces
{
    public interface ISingerRepository
    {
        Task<IEnumerable<Singer>> GetRandomSingersAsync(int amount);
    }
}
