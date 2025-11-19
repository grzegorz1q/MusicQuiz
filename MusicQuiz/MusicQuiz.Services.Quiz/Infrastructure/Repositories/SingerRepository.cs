using Microsoft.EntityFrameworkCore;
using MusicQuiz.Services.Quiz.Domain.Interfaces;
using MusicQuiz.Services.Quiz.Domain.Model;
using MusicQuiz.Services.Quiz.Infrastructure.Persistence;

namespace MusicQuiz.Services.Quiz.Infrastructure.Repositories
{
    public class SingerRepository : ISingerRepository
    {
        private readonly QuizDbContext _context;
        public SingerRepository(QuizDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Singer>> GetRandomSingersAsync(int amount)
        {
            return await _context.Singers.OrderBy(x => Guid.NewGuid()).Take(amount).ToListAsync();
        }
    }
}
