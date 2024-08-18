using MongoDB.Driver;
using MongoDB.Bson;

namespace GamepageAPI.Repositories
{
    public class MongoDbRepository
    {
        public MongoClient MongoClient { get; private set; }
        public IMongoDatabase MongoDB { get; private set; }

        public MongoDbRepository()
        {
            // Aquí pones tu URI de MongoDB Atlas
            const string connectionUri = "mongodb+srv://dyrivera490:Ak97j4XDCJm70SZr@cluster0.whkweoo.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

            // Configura MongoClientSettings usando el URI
            var settings = MongoClientSettings.FromConnectionString(connectionUri);

            // Configura ServerApi si es necesario
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            // Crea el cliente MongoDB y conéctate al servidor
            MongoClient = new MongoClient(settings);

            // Obtén la base de datos deseada
            MongoDB = MongoClient.GetDatabase("GamePage");

            // Opcional: Prueba la conexión
            try
            {
                var result = MongoDB.RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to MongoDB: " + ex.Message);
            }
        }
    }
}

