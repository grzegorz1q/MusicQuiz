using Microsoft.AspNetCore.Identity;
using MusicQuiz.Services.Identity.Application.Dtos;
using MusicQuiz.Services.Identity.Domain.Model;

namespace MusicQuiz.Services.Identity.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }
        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Nickname) ?? throw new UnauthorizedAccessException("Invalid nickname or password");
            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false) ?? throw new UnauthorizedAccessException("Invalid nickname or password");
            return _jwtService.GenerateToken(user);
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            var user = new User { UserName = dto.Nickname, Email = dto.Email, Nickname = dto.Nickname };
            await _userManager.CreateAsync(user, dto.Password);
        }
    }
}
