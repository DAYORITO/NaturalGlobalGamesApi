using GamepageAPI.Models;

namespace GamepageAPI.Repositories
{
    public interface IGameCollection
    {
        Task InsertGames(Games games);
        Task UpdateGames(Games games);
        Task DeleteGames(string id);
        Task<List<Games>> GetGames();
        Task<Games> GetGameById(string id);
    }
}
