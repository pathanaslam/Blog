using Blog.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Blog.services
{
    public class UserService
    {
        private readonly IMongoCollection<UserData> userdata;

        public UserService(IOptions<UserDatabaseSetting> userDatabaseSettings)
        {
            var mongoclient = new MongoClient(userDatabaseSettings.Value.ConnectionString);

            var mongodatabase = mongoclient.GetDatabase(userDatabaseSettings.Value.DatabaseName);

            userdata = mongodatabase.GetCollection<UserData>(userDatabaseSettings.Value.UserCollectionName);
        }

        public List<UserData> Get() =>
             userdata.Find(_ => true).ToList();

        public async Task CreateAsync(UserData newBook) =>
            await userdata.InsertOneAsync(newBook);
    }
}
