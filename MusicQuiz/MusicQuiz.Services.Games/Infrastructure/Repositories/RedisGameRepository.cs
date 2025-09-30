using MusicQuiz.Services.Games.Domain.Interfaces;
using MusicQuiz.Services.Games.Domain.Model;
using StackExchange.Redis;
using System.Text.Json;

namespace MusicQuiz.Services.Games.Infrastructure.Repositories
{
    public class RedisGameRepository : IGameRepository
    {
        private readonly IDatabase _database;
        private readonly JsonSerializerOptions _serializerOptions;
        private const string GameIdCounterKey = "game:id:counter";
        public RedisGameRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };
        }
        private async Task<int> GetNextIdAsync()
        {
            return (int)await _database.StringIncrementAsync(GameIdCounterKey);
        }
        private static RedisKey GetKey(int id) => $"game:{id}";
        public async Task AddAsync(Game game)
        {
            game.Id = await GetNextIdAsync();
            var json = JsonSerializer.Serialize(game, _serializerOptions);
            await _database.StringSetAsync(GetKey(game.Id), json);
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            var game = await _database.StringGetAsync(GetKey(id));
            if (game.IsNullOrEmpty) return null;
            return JsonSerializer.Deserialize<Game>(game!, _serializerOptions);
        }

        public async Task UpdateAsync(Game game)
        {
            var json = JsonSerializer.Serialize(game, _serializerOptions);
            await _database.StringSetAsync(GetKey(game.Id), json);
        }

        public async Task DeleteAsync(int id)
        {
            await _database.KeyDeleteAsync(GetKey(id));
        }
    }
}
