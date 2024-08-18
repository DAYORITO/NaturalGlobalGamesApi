using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using GamepageAPI.Models;
using GamepageAPI.Repositories;
using MongoDB.Bson;
using GamepageAPI.Services;

namespace GamepageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {

        private IGameCollection _gameCollection = new GameCollection();
        private readonly IObjectStoringServices _objectStoringService = new ObjectStoringService();

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            return Ok(await _gameCollection.GetGames());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameById(string id)
        {
            return Ok(await _gameCollection.GetGameById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateGame(IFormFile gameImage, [FromForm]Games game)
        {
            if (game == null)
            {
                return BadRequest();
            }
            if (game.GameName == string.Empty)
            {
                ModelState.AddModelError("GameName", "El nombre no deberia estar vacio!");
            }
            if (gameImage != null)
            {
                var imageUrl = await _objectStoringService.UploadImageAsync(gameImage, game.GameName);
                game.GameImage = imageUrl;
            }
            else {
                ModelState.AddModelError("GameImage", "No puede ir sin imagen");
            }
            await _gameCollection.InsertGames(game);
            return Created("Created", true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame([FromBody] Games games, string id)
        {
            if (games == null)
            {
                return BadRequest();
            }
            if (games.GameName == string.Empty)
            {
                ModelState.AddModelError("GameName", "El nombre no deberia estar vacio!");
            }
            games.IdGame = id;

            await _gameCollection.UpdateGames(games);
            return Created("Created", true);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGames(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            await _gameCollection.DeleteGames(id);
            return NoContent();
        }
    }
}
