using VideoGameStore.Core.Models;

namespace VideoGameStore.DataAccess.Repositories
{
    public interface IVideoGameRepository
    {
        Task<List<VideoGame>> GetVideoGames();
        Task<Guid> CreateVideoGame(VideoGame videoGame);
        Task<Guid> UpdateVideoGame(Guid id, string title, string platform, string developer, decimal price);
        Task<Guid> DeleteVideoGame(Guid id);
    }
}