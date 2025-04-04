using Microsoft.AspNetCore.Mvc;
using VideoGames.Application.Services;
using VideoGamesStore.Contracts;
using VideoGameStore.Core.Models;

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

        //[HttpGet("{id.guid}")]
        //public async Task<ActionResult<VideoGame>> GetVideoGameById(Guid id)
        //{
        //    var videoGame = await _videoGamesService.GetVideoGame(id);

        //    if (videoGame == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(videoGame);
        //}

        [HttpPost]
        public async Task<ActionResult<Guid>> AddVideoGame([FromBody] VideoGamesRequest request)
        {
            var (game, error) = VideoGame.Create(Guid.NewGuid(),
                request.Title,
                request.Platform,
                request.Developer,
                request.Price);

            if (!string.IsNullOrEmpty(error))
                return BadRequest(error);

            var gameId = await _videoGamesService.CreateVideoGame(game);

            return Ok(gameId);
        }

        [HttpPut("{id.guid}")]
        public async Task<ActionResult<Guid>> PutVideoGames(Guid id, [FromBody] VideoGamesRequest request)
        {
            var gameId = await _videoGamesService.UpdateVideoGame(
                id, 
                request.Title, 
                request.Platform, 
                request.Developer, 
                request.Price);

            return Ok(gameId);
        }

        [HttpDelete("{id.guid}")]
        public async Task<ActionResult<Guid>> DelVideoGame(Guid id)
        {
            return Ok(await _videoGamesService.DeleteVideoGame(id));
        }
    }
}
