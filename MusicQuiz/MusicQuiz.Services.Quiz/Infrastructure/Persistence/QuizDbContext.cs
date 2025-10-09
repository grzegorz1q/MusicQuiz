using Microsoft.EntityFrameworkCore;
using MusicQuiz.Services.Quiz.Domain.Model;
namespace MusicQuiz.Services.Quiz.Infrastructure.Persistence
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>()
                .HasOne(q => q.CorrectAnswer)
                .WithMany()
                .HasForeignKey(q => q.CorrectAnswerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Category)
                .WithMany(c => c.Questions)
                .HasForeignKey(q => q.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Singer)
                .WithMany(s => s.Questions)
                .HasForeignKey(q => q.SingerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Answers)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Singer)
                .WithMany(c => c.Answers)
                .HasForeignKey(a => a.SingerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
