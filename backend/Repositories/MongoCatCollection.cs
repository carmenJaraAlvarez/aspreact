using backend.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backend.Repositories
{
    public class MongoCatCollection : IMongoCatCollection
    {
        //adding
        internal MongoDBRepository repository = new MongoDBRepository();
        private IMongoCollection<MongoCat> collection;

        public MongoCatCollection()
        {
            collection = repository.db.GetCollection<MongoCat>("Cats");
        }

        //////// and async
        public async Task DeleteMongoCat(string id)
        {
            var filter = Builders<MongoCat>.Filter.Eq(c => c.Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<List<MongoCat>> GetAllMongoCats()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();//new BsonDocument()=empty filter
        }

        public async Task<MongoCat> GetMongoCat(string id)
        {
            return await collection.FindAsync(new BsonDocument { {"_id", new ObjectId(id) } }).Result.FirstAsync();//added '_' in Mongo
        }

        public async Task InsertMongoCat(MongoCat mcat)
        {
            await collection.InsertOneAsync(mcat);
        }

        public async Task UpdateMongoCat(MongoCat mcat)
        {
            var filter = Builders<MongoCat>.Filter.Eq(c => c.Id, mcat.Id);
            await collection.ReplaceOneAsync(filter, mcat);
        }
    }
}
