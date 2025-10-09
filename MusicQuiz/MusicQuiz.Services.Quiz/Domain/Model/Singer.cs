namespace MusicQuiz.Services.Quiz.Domain.Model
{
    public class Singer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Question> Questions { get; set; } = default!;
        public List<Answer> Answers { get; set; } = default!;
    }
}
