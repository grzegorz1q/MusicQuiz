using Microsoft.EntityFrameworkCore;
using MusicQuiz.Services.Quiz.Domain.Model;

namespace MusicQuiz.Services.Quiz.Infrastructure.Persistence
{
    public static class QuizDbSeeder
    {
        public static async Task SeedAsync(QuizDbContext context)
        {
            if (await context.Categories.AnyAsync() || await context.Questions.AnyAsync() || await context.Answers.AnyAsync())
                return;

            var yearCategory = new Category { Type = CategoryType.Year };
            var titleCategory = new Category { Type = CategoryType.Title };
            var textCategory = new Category { Type = CategoryType.Text };

            await context.Categories.AddRangeAsync(yearCategory, titleCategory, textCategory);
            await context.SaveChangesAsync();

            var singers = new List<Singer>
            {
                new Singer { Name = "Michael Jackson" },
                new Singer { Name = "Freddie Mercury" },
                new Singer { Name = "Elvis Presley" },
                new Singer { Name = "Madonna" },
                new Singer { Name = "Sanah" },
                new Singer { Name = "Wilki" },
                new Singer { Name = "Chłopcy z placu broni" },
                new Singer { Name = "Dżem" },
                new Singer { Name = "Lady Gaga" },
                new Singer { Name = "Nirvana" },
                new Singer { Name = "Queen" },
                new Singer { Name = "2 plus 1" },
            };

            var answersYears = new List<Answer>
            {
                new Answer { Content = "1980", Category = yearCategory },
                new Answer { Content = "1991", Category = yearCategory },
                new Answer { Content = "2000", Category = yearCategory },
                new Answer { Content = "2010", Category = yearCategory },
                new Answer { Content = "2009", Category = yearCategory },
                new Answer { Content = "2001", Category = yearCategory },
                new Answer { Content = "2023", Category = yearCategory },
                new Answer { Content = "2024", Category = yearCategory },
                new Answer { Content = "2025", Category = yearCategory },
                new Answer { Content = "2002", Category = yearCategory },
                new Answer { Content = "1982", Category = yearCategory },
            };

            var answersTitles = new List<Answer>
            {
                new Answer { Content = "Thriller", Category = titleCategory, Singer = singers.First(s => s.Name == "Michael Jackson") },
                new Answer { Content = "Bohemian Rhapsody", Category = titleCategory, Singer = singers.First(s => s.Name == "Queen") },
                new Answer { Content = "Jailhouse Rock", Category = titleCategory, Singer = singers.First(s => s.Name == "Elvis Presley") },
                new Answer { Content = "Like a Virgin", Category = titleCategory, Singer = singers.First(s => s.Name == "Madonna") },
                new Answer { Content = "Szampan", Category = titleCategory, Singer = singers.First(s => s.Name == "Sanah") },
                new Answer { Content = "Windą do nieba", Category = titleCategory, Singer = singers.First(s => s.Name == "2 plus 1") },
                new Answer { Content = "Whisky", Category = titleCategory, Singer = singers.First(s => s.Name == "Dżem") },
                new Answer { Content = "Poker Face", Category = titleCategory, Singer = singers.First(s => s.Name == "Lady Gaga") },
                new Answer { Content = "Smells Like Teen Spirit", Category = titleCategory, Singer = singers.First(s => s.Name == "Nirvana") },
                new Answer { Content = "Don't stop till you get enough", Category = titleCategory, Singer = singers.First(s => s.Name == "Michael Jackson") },
            };

            var answersText = new List<Answer>
            {
                new Answer { Content = "Don't stop me now", Category = textCategory },
                new Answer { Content = "I wanna be loved by you", Category = textCategory },
                new Answer { Content = "We will, we will rock you", Category = textCategory },
                new Answer { Content = "Like a virgin", Category = textCategory },
                new Answer { Content = "Szampan na stoliku", Category = textCategory },
                new Answer { Content = "Nie płacz Ewka", Category = textCategory },
                new Answer { Content = "Windą do nieba", Category = textCategory },
                new Answer { Content = "I will survive", Category = textCategory },
                new Answer { Content = "Just dance", Category = textCategory },
                new Answer { Content = "Here we are now, entertain us", Category = textCategory },
            };

            var questions = new List<Question>
            {
                new Question
                {
                    Content = "W którym roku wydano 'Smells Like Teen Spirit'?",
                    Singer = singers.First(s => s.Name == "Nirvana"),
                    Category = yearCategory,
                    CorrectAnswer = answersYears.First(a => a.Content == "1991")
                },
                new Question 
                { 
                    Content = "W którym roku wydano album 'Thriller'?", 
                    Singer = singers.First(s => s.Name == "Michael Jackson"), 
                    Category = yearCategory, 
                    CorrectAnswer = answersYears.First(a => a.Content == "1982") 
                },
                new Question 
                { 
                    Content = "W jakiej piosence znajduje się fragment tekstu 'Keep on, with the force'?",
                    Singer = singers.First(s => s.Name == "Michael Jackson"), 
                    Category = titleCategory, 
                    CorrectAnswer = answersTitles.First(a => a.Content == "Don't stop till you get enough") 
                },
            };
        }
    }
}
