namespace MusicQuiz.Services.Quiz.Domain.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public int CorrectAnswerId { get; set; }
        public Answer CorrectAnswer { get; set; } = default!;
        public int SingerId { get; set; }
        public Singer Singer { get; set; } = default!;
    }
}
