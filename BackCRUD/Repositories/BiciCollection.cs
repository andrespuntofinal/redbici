using BackCRUD.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackCRUD.Repositories
{
    public class BiciCollection : IBiciCollection
    {


        internal MongoDBRepository _repository = new MongoDBRepository();

        private IMongoCollection<Bicicletas> collection;

        public BiciCollection()
        {

            collection = _repository.db.GetCollection<Bicicletas>("Bicicletas");

        }
        public async Task DeleteBici(string id)
        {

            var filter = Builders<Bicicletas>.Filter.Eq(s => s.Id, new ObjectId(id));

            await collection.DeleteOneAsync(filter);


        }

        public async Task<List<Bicicletas>> GetAllBicicletas()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();

        }

        public async Task<Bicicletas> GetBicicletasById(string id)
        {
            return await collection.FindAsync(
                   new BsonDocument { { "_id", new ObjectId(id) } }).Result.
                   FirstAsync();


                
        }

        public async Task InsertBici(Bicicletas bicicleta)
        {
            await collection.InsertOneAsync(bicicleta);
        }

        public async Task UpdateBici(Bicicletas bicicleta)
        {

            var filter = Builders<Bicicletas>
                .Filter
                .Eq(s => s.Id, bicicleta.Id);

            await collection.ReplaceOneAsync(filter, bicicleta);

        }
    }
}
