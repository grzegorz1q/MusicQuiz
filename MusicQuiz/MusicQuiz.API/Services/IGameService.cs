using MusicQuiz.API.Dtos;

namespace MusicQuiz.API.Services
{
    public interface IGameService
    {
        Task<IEnumerable<PlayerDto>> GetCurrentPlayers(int gameId);
    }
}
