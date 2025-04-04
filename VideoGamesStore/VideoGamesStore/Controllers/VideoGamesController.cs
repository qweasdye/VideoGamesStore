using Microsoft.AspNetCore.Mvc;
using VideoGames.Application.Services;
using VideoGamesStore.Contracts;

namespace VideoGamesStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGamesService _videoGamesService;

        public VideoGamesController(IVideoGamesService videoGamesService)
        {
            _videoGamesService = videoGamesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoGamesResponse>>> GetVideoGames()
        {
            var videoGames = await _videoGamesService.GetAllVideoGames();

            var responce = videoGames.Select(v => new VideoGamesResponse(v.Id, v.Title, v.Platform, v.Developer, v.Price));

            return Ok(responce);
        }
    }
}
