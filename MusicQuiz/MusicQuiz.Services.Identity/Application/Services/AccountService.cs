using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            var user = await _userManager.FindByNameAsync(dto.Username) ?? throw new UnauthorizedAccessException("Invalid nickname or password");
            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded)
                throw new UnauthorizedAccessException("Invalid nickname or password");
            return _jwtService.GenerateToken(user);
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
        {
            var user = new User { UserName = dto.Username, Email = dto.Email};
            return await _userManager.CreateAsync(user, dto.Password);
        }
        public async Task<UserDto> GetUserAsync(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id) ?? throw new KeyNotFoundException("User not found");
            return new UserDto(user.Id, user.UserName!);
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return users.Select(u => new UserDto(u.Id, u.UserName!));
        }
    }
}
