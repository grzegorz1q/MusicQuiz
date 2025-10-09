using Microsoft.AspNetCore.Identity;
using MusicQuiz.Services.Identity.Domain.Model;

namespace MusicQuiz.Services.Identity.Infrastructure.Persistence
{
    public class UsersSeed
    {
        private readonly ILogger<UsersSeed> _logger;
        private readonly UserManager<User> _userManager;

        public UsersSeed(ILogger<UsersSeed> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            await CreateUserIfNotExists("adam", "adam@email.com", "Password123!");
            await CreateUserIfNotExists("bob", "bob@email.com", "Password123!");
            await CreateUserIfNotExists("anna", "anna@email.com", "Password123!");
        }

        private async Task CreateUserIfNotExists(string username, string email, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                user = new User
                {
                    UserName = username,
                    Email = email
                };

                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to create user {username}: {errors}");
                }

                _logger.LogInformation($"User {username} created successfully");
            }
            else
            {
                _logger.LogInformation($"User {username} already exists");
            }
        }
    }
}
