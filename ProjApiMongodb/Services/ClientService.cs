using MongoDB.Driver;
using ProjApiMongodb.Config;
using ProjApiMongodb.Models;

namespace ProjApiMongodb.Services
{
    public class ClientService
    {
        private readonly IMongoCollection<Client> _client;
        public ClientService(IProjMdSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString); // recebe a conexao
            var database = client.GetDatabase(settings.DatabaseName);
            _client = database.GetCollection<Client>(settings.DatabaseName);
        }

        public List<Client> Get() => _client.Find(c => true).ToList(); // esse c=> true é o mems oque usar while(true)... vai devolver os Client ate acabar
      

        public Client Get(string Id) => _client.Find(c => c.Id == Id).FirstOrDefault();
        public Client Create(Client client)
        {
            _client.InsertOne(client);
            return client;
        }

        public void Update(string id, Client client) => _client.ReplaceOne(c => c.Id == id, client);
        
        public void Delete(string id) => _client.DeleteOne(c => c.Id == id);

        public void Delete(Client client) => _client.DeleteOne(c => c.Id == client.Id);





    }
}
