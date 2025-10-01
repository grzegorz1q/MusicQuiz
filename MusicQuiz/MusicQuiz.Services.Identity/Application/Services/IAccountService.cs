using Microsoft.AspNetCore.Identity;
using MusicQuiz.Services.Identity.Application.Dtos;

namespace MusicQuiz.Services.Identity.Application.Services
{
    public interface IAccountService
    {
        Task<string> LoginAsync(LoginDto dto);
        Task<IdentityResult> RegisterAsync(RegisterDto dto);
    }
}
