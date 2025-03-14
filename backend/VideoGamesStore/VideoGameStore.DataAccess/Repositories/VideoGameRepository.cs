using Microsoft.EntityFrameworkCore;
using VideoGameStore.Core.Models;
using VideoGameStore.DataAccess.Entities;

namespace VideoGameStore.DataAccess.Repositories
{
    public class VideoGameRepository : IVideoGameRepository
    {
        private readonly VideoGamesStoreDbContext _context;

        public VideoGameRepository(VideoGamesStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<VideoGame>> GetVideoGames()
        {
            var videoGameEntities = await _context.VideoGame
                .AsNoTracking()
                .ToListAsync();

            var games = videoGameEntities
                .Select(v => VideoGame.Create(v.Id, v.Title, v.Platform, v.Developer, v.Price)
                .VideoGame)
                .ToList();

            return games;
        }

        public async Task<Guid> CreateVideoGame(VideoGame videoGame)
        {
            var videoGameEntities = new VideoGameEntity
            {
                Id = videoGame.Id,
                Title = videoGame.Title,
                Platform = videoGame.Platform,
                Developer = videoGame.Developer,
                Price = videoGame.Price
            };

            await _context.VideoGame.AddAsync(videoGameEntities);
            await _context.SaveChangesAsync();

            return videoGameEntities.Id;
        }

        public async Task<Guid> UpdateVideoGame(Guid id, string title, string platform, string developer, decimal price)
        {
            await _context.VideoGame
                .Where(v => v.Id == id).
                ExecuteUpdateAsync(s => s
                .SetProperty(v => v.Title, v => title)
                .SetProperty(v => v.Platform, v => platform)
                .SetProperty(v => v.Developer, v => developer)
                .SetProperty(v => v.Price, v => price));

            return id;
        }

        public async Task<Guid> DeleteVideoGame(Guid id)
        {
            await _context.VideoGame
                .Where(v => v.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
