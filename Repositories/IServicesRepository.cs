using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IServicesRepository
    {
        Task<Service> GetServiceAsync(Guid id);
        Task<IEnumerable<Service>> GetServicesAsync();
        //Task<Service> GetImageAsync(Guid id);
        Task CreateServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(Guid id);
    }
}