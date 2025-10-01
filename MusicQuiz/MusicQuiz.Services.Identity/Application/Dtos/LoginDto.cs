using Microsoft.Identity.Client;

namespace MusicQuiz.Services.Identity.Application.Dtos
{
    public class LoginDto
    {
        public string Nickname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
