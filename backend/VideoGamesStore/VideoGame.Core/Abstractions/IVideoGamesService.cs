using VideoGameStore.Core.Models;

namespace VideoGames.Application.Services
{
    public interface IVideoGamesService
    {
        Task<List<VideoGame>> GetAllVideoGames();
        Task<Guid> CreateVideoGame(VideoGame videoGame);
        Task<Guid> UpdateVideoGame(Guid id, string title, string platform, string developer, decimal price);
        Task<Guid> DeleteVideoGame(Guid id);
    }
}