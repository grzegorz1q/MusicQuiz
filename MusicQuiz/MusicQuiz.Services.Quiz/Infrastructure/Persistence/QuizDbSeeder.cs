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
                //new Singer { Name = "Freddie Mercury" },
                new Singer { Name = "Queen" },
                new Singer { Name = "Elvis Presley" },
                new Singer { Name = "Madonna" },
                new Singer { Name = "Sanah" },
                //new Singer { Name = "Wilki" },
                //new Singer { Name = "Chłopcy z placu broni" },
                new Singer { Name = "Dżem" },
                //new Singer { Name = "Lady Gaga" },
                new Singer { Name = "2 plus 1" }
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
                new Answer { Content = "Don't stop till you get enough", Category = titleCategory, Singer = singers.First(s => s.Name == "Michael Jackson") },
                new Answer { Content = "Smooth Criminal", Category = titleCategory, Singer = singers.First(s => s.Name == "Michael Jackson") },
                new Answer { Content = "Billie Jean", Category = titleCategory, Singer = singers.First(s => s.Name == "Michael Jackson") },
                new Answer { Content = "Bohemian Rhapsody", Category = titleCategory, Singer = singers.First(s => s.Name == "Queen") },
                new Answer { Content = "Don't stop me now", Category = titleCategory, Singer = singers.First(s => s.Name == "Queen") },
                new Answer { Content = "We will rock you", Category = titleCategory, Singer = singers.First(s => s.Name == "Queen") },
                new Answer { Content = "We Are the Champions", Category = titleCategory, Singer = singers.First(s => s.Name == "Queen") },
                new Answer { Content = "Jailhouse Rock", Category = titleCategory, Singer = singers.First(s => s.Name == "Elvis Presley") },
                new Answer { Content = "My Way", Category = titleCategory, Singer = singers.First(s => s.Name == "Elvis Presley") },
                new Answer { Content = "Always on my mind", Category = titleCategory, Singer = singers.First(s => s.Name == "Elvis Presley") },
                new Answer { Content = "In the ghetto", Category = titleCategory, Singer = singers.First(s => s.Name == "Elvis Presley") },
                new Answer { Content = "Like a Virgin", Category = titleCategory, Singer = singers.First(s => s.Name == "Madonna") },
                new Answer { Content = "Hung up", Category = titleCategory, Singer = singers.First(s => s.Name == "Madonna") },
                new Answer { Content = "Material girl", Category = titleCategory, Singer = singers.First(s => s.Name == "Madonna") },
                new Answer { Content = "Crazy For You", Category = titleCategory, Singer = singers.First(s => s.Name == "Madonna") },
                new Answer { Content = "Szampan", Category = titleCategory, Singer = singers.First(s => s.Name == "Sanah") },
                new Answer { Content = "Ale jazz!", Category = titleCategory, Singer = singers.First(s => s.Name == "Sanah") },
                new Answer { Content = "Jestem Twoją Bajką", Category = titleCategory, Singer = singers.First(s => s.Name == "Sanah") },
                new Answer { Content = "było, minęło", Category = titleCategory, Singer = singers.First(s => s.Name == "Sanah") },
                new Answer { Content = "Windą do nieba", Category = titleCategory, Singer = singers.First(s => s.Name == "2 plus 1") },
                new Answer { Content = "Chodź, pomaluj mój świat", Category = titleCategory, Singer = singers.First(s => s.Name == "2 plus 1") },
                new Answer { Content = "Wielki Mały Człowiek", Category = titleCategory, Singer = singers.First(s => s.Name == "2 plus 1") },
                new Answer { Content = "Iść w stronę słońca", Category = titleCategory, Singer = singers.First(s => s.Name == "2 plus 1") },
                new Answer { Content = "Whisky", Category = titleCategory, Singer = singers.First(s => s.Name == "Dżem") },
                new Answer { Content = "Wehikuł czasu", Category = titleCategory, Singer = singers.First(s => s.Name == "Dżem") },
                new Answer { Content = "Sen o Victorii", Category = titleCategory, Singer = singers.First(s => s.Name == "Dżem") },
                new Answer { Content = "List do M.", Category = titleCategory, Singer = singers.First(s => s.Name == "Dżem") }
            };

            var answersText = new List<Answer>
            {
                new Answer { Content = "Nie płacz Ewka", Category = textCategory },
                new Answer { Content = "Just dance", Category = textCategory },
                new Answer { Content = "Here we are now, entertain us", Category = textCategory },
            };

            var questions = new List<Question>
            {
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
                new Question
                {
                    Content = "Tańczące zombie",
                    Singer = singers.First(s => s.Name == "Michael Jackson"),
                    Category = titleCategory,
                    CorrectAnswer = answersTitles.First(a => a.Content == "Thriller")
                },
                new Question
                {
                    Content = "W jakim utworze Queen pojawiają się postacie takie jak Scaramouche i Galileo?",
                    Singer = singers.First(s => s.Name == "Queen"),
                    Category = titleCategory,
                    CorrectAnswer = answersTitles.First(a => a.Content == "Bohemian Rapsody")
                },
                new Question
                {
                    Content = "Ten utwór Queen nie ma refrenu, a mimo to stał się jednym z najbardziej rozpoznawalnych w historii muzyki.",
                    Singer = singers.First(s => s.Name == "Queen"),
                    Category = titleCategory,
                    CorrectAnswer = answersTitles.First(a => a.Content == "Bohemian Rapsody")
                },
                new Question
                {
                    Content = "Najbardziej poprawiający nastrój kawałek wszech czasów",
                    Singer = singers.First(s => s.Name == "Queen"),
                    Category = titleCategory,
                    CorrectAnswer = answersTitles.First(a => a.Content == "Don't stop me now")
                },
                new Question
                {
                    Content = "Który utwór Queen często grany jest po wygranych meczach i imprezach sportowych na całym świecie?",
                    Singer = singers.First(s => s.Name == "Queen"),
                    Category = titleCategory,
                    CorrectAnswer = answersTitles.First(a => a.Content == "We Are the Champions")
                },
                new Question
                {
                    Content = "Który utwór opowiada o zabawie tanecznej w więzieniu?",
                    Singer = singers.First(s => s.Name == "Elvis Presley"),
                    Category = titleCategory,
                    CorrectAnswer = answersTitles.First(a => a.Content == "Jailhouse Rock")
                },
                new Question
                {
                    Content = "W którym utworze Madonna występuje w teledysku inspirowanym numerem “Diamonds Are a Girl’s Best Friend” z Marilyn Monroe?",
                    Singer = singers.First(s => s.Name == "Madonna"),
                    Category = titleCategory,
                    CorrectAnswer = answersTitles.First(a => a.Content == "Material girl")
                },
                new Question
                {
                    Content = "Piosenka z Akademii Pana Kleksa",
                    Singer = singers.First(s => s.Name == "Sanah"),
                    Category = titleCategory,
                    CorrectAnswer = answersTitles.First(a => a.Content == "Jestem Twoją Bajką")
                },
                new Question
                {
                    Content = "Ten utwór zespołu stał się jednym z hymnów pozytywnego myślenia w PRL-u.",
                    Singer = singers.First(s => s.Name == "2 plus 1"),
                    Category = titleCategory,
                    CorrectAnswer = answersTitles.First(a => a.Content == "Iść w stronę słońca")
                },
                new Question
                {
                    Content = "W jakiej piosence Ryszard Riedel śpiewa o tęsknocie i poszukiwaniu sensu życia?",
                    Singer = singers.First(s => s.Name == "Dżem"),
                    Category = titleCategory,
                    CorrectAnswer = answersTitles.First(a => a.Content == "List do M.")
                },
            };
        }
    }
}
