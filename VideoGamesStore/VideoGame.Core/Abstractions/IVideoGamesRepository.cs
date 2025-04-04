using VideoGameStore.Core.Models;

namespace VideoGameStore.DataAccess.Repositories
{
    public interface IVideoGamesRepository
    {
        Task<List<VideoGame>> Get();
        //Task<Guid> GetById(Guid id);
        Task<Guid> Create(VideoGame videoGame);
        Task<Guid> Update(Guid id, string title, string platform, string developer, decimal price);
        Task<Guid> Delete(Guid id);
    }
}