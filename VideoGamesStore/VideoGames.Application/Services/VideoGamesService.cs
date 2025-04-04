using VideoGameStore.DataAccess.Repositories;
using VideoGameStore.Core.Models;

namespace VideoGames.Application.Services
{
    public class VideoGamesService : IVideoGamesService
    {
        private readonly IVideoGamesRepository _videoGamesRepository;

        public VideoGamesService(IVideoGamesRepository videoGamesRepository)
        {
            _videoGamesRepository = videoGamesRepository;
        }

        public async Task<List<VideoGame>> GetAllVideoGames()
        {
            return await _videoGamesRepository.Get();
        }

        public async Task<Guid> CreateVideoGame(VideoGame videoGame)
        {
            return await _videoGamesRepository.Create(videoGame);
        }

        public async Task<Guid> UpdateVideoGame(Guid id, string title, string platform, string developer, decimal price)
        {
            return await _videoGamesRepository.Update(id, title, platform, developer, price);
        }

        public async Task<Guid> DeleteVideoGame(Guid id)
        {
            return await _videoGamesRepository.Delete(id);
        }
    }
}
