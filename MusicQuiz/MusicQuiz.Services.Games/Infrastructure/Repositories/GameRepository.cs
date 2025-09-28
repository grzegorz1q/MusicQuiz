using Microsoft.EntityFrameworkCore;
using MusicQuiz.Services.Games.Domain.Model;
using MusicQuiz.Services.Games.Infrastructure.Persistence;

namespace MusicQuiz.Services.Games.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GamesDbContext _context;
        public GameRepository(GamesDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games.Include(g => g.GameScores).FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task UpdateAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }
    }
}
