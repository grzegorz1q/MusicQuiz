using Microsoft.EntityFrameworkCore;
using MusicQuiz.Services.Scoreboard.Domain.Interfaces;
using MusicQuiz.Services.Scoreboard.Domain.Model;
using MusicQuiz.Services.Scoreboard.Infrastructure.Persistence;

namespace MusicQuiz.Services.Scoreboard.Infrastructure.Repositories
{
    public class PlayerScoreRepository : IPlayerScoreRepository
    {
        private readonly ScoreboardDbContext _context;
        public PlayerScoreRepository(ScoreboardDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(PlayerScore playerScore)
        {
            await _context.PlayerScores.AddAsync(playerScore);
            await _context.SaveChangesAsync();
        }

        public async Task<PlayerScore?> GetByIdAsync(int id)
        {
            return await _context.PlayerScores.FirstOrDefaultAsync(ps => ps.Id == id);
        }

        public async Task UpdateAsync(PlayerScore playerScore)
        {
            _context.PlayerScores.Update(playerScore);
            await _context.SaveChangesAsync();
        }
    }
}
