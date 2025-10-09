using System.ComponentModel.DataAnnotations;

namespace MusicQuiz.Services.Identity.Application.Dtos
{
    public record LoginDto([Required]  string Username, [Required]  string Password);
}
