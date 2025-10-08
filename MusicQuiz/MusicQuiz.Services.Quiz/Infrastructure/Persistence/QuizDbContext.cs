using Microsoft.EntityFrameworkCore;
using MusicQuiz.Services.Quiz.Domain.Model;
namespace MusicQuiz.Services.Quiz.Infrastructure.Persistence
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>()
                .HasOne(q => q.CorrectAnswer)
                .WithMany()
                .HasForeignKey(q => q.CorrectAnswerId);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Category)
                .WithMany(c => c.Questions)
                .HasForeignKey(q => q.CategoryId);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Answers)
                .HasForeignKey(a => a.CategoryId);
        }
    }
}
