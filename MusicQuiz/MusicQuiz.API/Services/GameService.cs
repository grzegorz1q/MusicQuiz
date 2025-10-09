using MusicQuiz.API.Dtos;

namespace MusicQuiz.API.Services
{
    public class GameService : IGameService
    {
        private readonly HttpClient _httpClient;
        private readonly string _gamesUrl = "https://localhost:7249/api/games";
        private readonly string _identityUsersUrl = "https://localhost:7272/api/account/users";
        public GameService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GameDto> GetGameState(int id)
        {
            var gameTask = _httpClient.GetFromJsonAsync<GameEntryDto>($"{_gamesUrl}/{id}");
            var usersTask = _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>(_identityUsersUrl);

            await Task.WhenAll(gameTask, usersTask);
            var game = gameTask.Result ?? throw new KeyNotFoundException("Game not found!");
            var users = usersTask.Result ?? throw new KeyNotFoundException("Users list is empty");

            return new GameDto(
                game.Id,
                game.CurrentRound,
                game.StartedAt,
                game.PlayerScores.Select(ps => new PlayerScoreDto(
                    ps.Score,
                    users.FirstOrDefault(u => u.Id == ps.PlayerId)?.Username ?? "Unknown"
                    )
                ).ToList()
            );
        }
    }
}
