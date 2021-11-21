using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbServicesRepository : IServicesRepository
    {
        private const string databaseName = "catalog";
        private const string collectionName = "services";
        
        private readonly IMongoCollection<Service> servicesCollection;
        private readonly FilterDefinitionBuilder<Service> filterBuilder = Builders<Service>.Filter;
        
        public MongoDbServicesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            servicesCollection = database.GetCollection<Service>(collectionName);
        }

        // post /services
        // needs parameters { "name" : "", "description" : "", "price" : }
        public async Task CreateServiceAsync(Service service)
        {
            await servicesCollection.InsertOneAsync(service);
        }

        // delete /services/id
        // needs id as parameter
        public async Task DeleteServiceAsync(Guid id)
        {
            var filter = filterBuilder.Eq(service => service.Id, id);
            await servicesCollection.DeleteOneAsync(filter);
        }

        /*
        public async Task<Service> GetImageAsync(Guid id)
        {
            var filter = filterBuilder.Eq(service => service.Id, id);
            return await servicesCollection.Find(filter).SingleOrDefaultAsync();
        }
        */

        // get /services/id
        // needs id as parameter
        public async Task<Service> GetServiceAsync(Guid id)
        {
            var filter = filterBuilder.Eq(service => service.Id, id);
            return await servicesCollection.Find(filter).SingleOrDefaultAsync();
        }

        // get /services
        // no additional parameter needed
        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            return await servicesCollection.Find(new BsonDocument()).ToListAsync();
        }

        // put /services/id
        // needs id as parameter
        public async Task UpdateServiceAsync(Service service)
        {
            var filter = filterBuilder.Eq(existingService => existingService.Id, service.Id);
            await servicesCollection.ReplaceOneAsync(filter, service);
        }
    }
}