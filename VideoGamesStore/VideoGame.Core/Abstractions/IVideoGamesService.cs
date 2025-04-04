using VideoGameStore.Core.Models;

namespace VideoGames.Application.Services
{
    public interface IVideoGamesService
    {
        Task<List<VideoGame>> GetAllVideoGames();
        //Task<VideoGame> GetVideoGame(Guid id);
        Task<Guid> CreateVideoGame(VideoGame videoGame);
        Task<Guid> UpdateVideoGame(Guid id, string title, string platform, string developer, decimal price);
        Task<Guid> DeleteVideoGame(Guid id);
    }
}