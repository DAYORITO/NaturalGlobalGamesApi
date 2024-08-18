using MongoDB.Driver;

namespace GamepageAPI.Repositories
{
    public class MongoDbRepository
    {
        public MongoClient MongoClient;

        public IMongoDatabase mongoDB;

        public MongoDbRepository()
        {
            MongoClient = new MongoClient("mongodb://localhost:27017/");
            mongoDB = MongoClient.GetDatabase("Gamepage");
        }
    }
}
