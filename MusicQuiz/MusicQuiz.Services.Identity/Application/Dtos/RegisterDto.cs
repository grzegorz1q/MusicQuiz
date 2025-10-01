namespace MusicQuiz.Services.Identity.Application.Dtos
{
    public class RegisterDto
    {
        public string Nickname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPasswrod { get; set; } = string.Empty;
    }
}
