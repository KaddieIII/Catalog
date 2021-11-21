using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{

    public class InMemServicesRepository : IServicesRepository
    {
        // just a few default services
        private readonly List<Service> services = new()
        {
            new Service { Id = Guid.NewGuid(), Name = "Hochzeitsfeier", Description = "", Price = 250, Picture = "..\\Resources\\wedding_party.jpg" , CreatedDate = DateTimeOffset.UtcNow },
            new Service { Id = Guid.NewGuid(), Name = "Bike Sharing", Description = "", Price = 2, Picture = "..\\Resources\\bike_sharing.jpg"  , CreatedDate = DateTimeOffset.UtcNow },
            new Service { Id = Guid.NewGuid(), Name = "Rent a car", Description = "", Price = 10, Picture = "..\\Resources\\car_sharing.jpg"  , CreatedDate = DateTimeOffset.UtcNow },
        };

        // get /services
        // no additional parameter needed
        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            return await Task.FromResult(services);
        }

        // get /services/id
        // needs id as parameter
        public async Task<Service> GetServiceAsync(Guid id)
        {
            var service = services.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(service);
        }

        // post /services
        // needs parameters { "name" : "", "description" : "", "price" : }
        public async Task CreateServiceAsync(Service service)
        {
            services.Add(service);
            await Task.CompletedTask;
        }

        // put /services/id
        // needs id as parameter
        public async Task UpdateServiceAsync(Service service)
        {
            var index = services.FindIndex(existingService => existingService.Id == service.Id);
            services[index] = service;
            await Task.CompletedTask;
        }

        // delete /services/id
        // needs id as parameter
        public async Task DeleteServiceAsync(Guid id)
        {
            var index = services.FindIndex(existingService => existingService.Id == id);
            services.RemoveAt(index);
            await Task.CompletedTask;
        }

        // get /services/{id}/image
        // needs id as parameter
        /*
        public async Task<Service> GetImageAsync(Guid id)
        {
            var service = services.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(service);
        }
        */
    }
}