using MusicQuiz.Services.Identity.Domain.Model;

namespace MusicQuiz.Services.Identity.Application.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
