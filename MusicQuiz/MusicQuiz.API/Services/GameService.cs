using MusicQuiz.API.Dtos;

namespace MusicQuiz.API.Services
{
    public class GameService : IGameService
    {
        private readonly HttpClient _httpClient;
        private readonly string _gameUrl = "https://localhost:7249/api/games";
        private readonly string _identityUsersUrl = "https://localhost:7272/api/account/users";
        public GameService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<PlayerDto>> GetCurrentPlayers(int gameId)
        {
            var users = await _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>(_identityUsersUrl);
            if (users == null || !users.Any())
                throw new KeyNotFoundException("Users list is empty");
            var game = await _httpClient.GetFromJsonAsync<GameDto>($"{_gameUrl}/{gameId}") ?? throw new KeyNotFoundException("Game not found");

            return game.PlayerScores.Select(ps => new PlayerDto(
                    users.FirstOrDefault(u => u.Id == ps.PlayerId)?.Username ?? "Unknown",
                    ps.Score
                )
            );
        }
    }
}
