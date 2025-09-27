using Microsoft.EntityFrameworkCore;
using MusicQuiz.Services.Games.Domain.Model;

namespace MusicQuiz.Services.Games.Infrastructure.Persistence
{
    public class GamesDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameScore> GameScores { get; set; }
        public GamesDbContext(DbContextOptions<GamesDbContext> optionsBuilder) : base(optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
