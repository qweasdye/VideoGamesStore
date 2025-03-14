using Microsoft.EntityFrameworkCore;
using VideoGameStore.DataAccess.Entities;

namespace VideoGameStore.DataAccess
{
    public class VideoGamesStoreDbContext : DbContext
    {
        public VideoGamesStoreDbContext(DbContextOptions<VideoGamesStoreDbContext> options) : base(options) 
        {
            
        }

        public DbSet<VideoGameEntity> VideoGame { get; set; }
    }
}