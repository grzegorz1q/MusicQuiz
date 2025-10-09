using MusicQuiz.API.Dtos;

namespace MusicQuiz.API.Services
{
    public class ScoreboardService : IScoreboardService
    {
        private readonly HttpClient _httpClient;
        private readonly string _scoreboardUrl = "https://localhost:7232/api/scoreboard";
        private readonly string _identityUsersUrl = "https://localhost:7272/api/account/users";
        public ScoreboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ScoreboardDto>> GetScoreboardAsync()
        {
            var usersTask = _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>(_identityUsersUrl);
            var scoreboardTask = _httpClient.GetFromJsonAsync<IEnumerable<ScoreboardEntryDto>>(_scoreboardUrl);

            await Task.WhenAll(usersTask, scoreboardTask);

            var users = usersTask.Result ?? throw new KeyNotFoundException("Users list is empty");
            var scoreboard = scoreboardTask.Result ?? throw new KeyNotFoundException("Scoreboard list is empty");

            return scoreboard.Select(s => new ScoreboardDto(
                    users.FirstOrDefault(u => u.Id == s.PlayerId)?.Username ?? "Unknown",
                    s.TotalScore,
                    s.GamesPlayed
                )
            );
        }

    }
}
