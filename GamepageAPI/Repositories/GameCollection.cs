using GamepageAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GamepageAPI.Repositories
{
    public class GameCollection : IGameCollection
    {
        internal MongoDbRepository _mongoDbRepository = new MongoDbRepository();
        private IMongoCollection<Games> Collection;

        public GameCollection() 
        {
            Collection = _mongoDbRepository.MongoDB.GetCollection<Games>("Games");
        }
        public async Task DeleteGames(string id)
        {
            var filter = Builders<Games>.Filter.Eq(s => s.IdGame, id);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<Games> GetGameById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { {"_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<List<Games>> GetGames()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task InsertGames(Games games)
        {
            await Collection.InsertOneAsync(games);
        }

        public async Task UpdateGames(Games games)
        {
            var filter = Builders<Games>.Filter.Eq(s => s.IdGame, games.IdGame);
            await Collection.ReplaceOneAsync(filter, games);
        }
    }
}
