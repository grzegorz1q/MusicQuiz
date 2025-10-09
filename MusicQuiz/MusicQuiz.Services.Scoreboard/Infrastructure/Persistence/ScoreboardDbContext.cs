using Microsoft.EntityFrameworkCore;
using MusicQuiz.Services.Scoreboard.Domain.Model;

namespace MusicQuiz.Services.Scoreboard.Infrastructure.Persistence
{
    public class ScoreboardDbContext : DbContext
    {
        public DbSet<PlayerScore> PlayerScores { get; set; }
        public ScoreboardDbContext(DbContextOptions<ScoreboardDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
