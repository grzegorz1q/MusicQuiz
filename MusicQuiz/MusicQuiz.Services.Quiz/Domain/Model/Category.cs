namespace MusicQuiz.Services.Quiz.Domain.Model
{
    public class Category
    {
        public int Id { get; set; }
        public CategoryType Type { get; set; }
        public List<Question> Questions { get; set; } = default!;
        public List<Answer> Answers { get; set; } = default!;
    }
}
