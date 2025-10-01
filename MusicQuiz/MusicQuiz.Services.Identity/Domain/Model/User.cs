using Microsoft.AspNetCore.Identity;

namespace MusicQuiz.Services.Identity.Domain.Model
{
    public class User : IdentityUser
    {
        public string Nickname { get; set; } = string.Empty;
    }
}
