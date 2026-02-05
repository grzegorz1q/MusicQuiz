using MusicQuiz.API.Dtos;

namespace MusicQuiz.API.Services
{
    public interface IGameService
    {
        //Task<GameDto> GetGameState(int id);
        Task<GameDto> CreateGame(CreateGameDto createGameDto);
    }
}
