using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;
using Catalog.Repositories;
using Catalog.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("services")]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesRepository repository;
        
        public ServicesController(IServicesRepository repository)
        {
            this.repository = repository;
        }

        // GET /services
        [HttpGet]
        public async Task<IEnumerable<ServiceDto>> GetServicesAsync()
        {
            var services = (await repository.GetServicesAsync())
                            .Select( service => service.AsDto());
            return services;
        }

        // GET /services/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDto>> GetServiceAsync(Guid id)
        {
            var service = await repository.GetServiceAsync(id);

            if (service is null)
            {
                return NotFound();
            }

            return service.AsDto();
        }

        // POST /services
        // needs additional parameters { "name" : "" , "description" : "" , "price" : }
        [HttpPost]
        public async Task<ActionResult<ServiceDto>> CreateServiceAsync(CreateServiceDto serviceDto)
        {
            Service service = new(){
                Id = Guid.NewGuid(),
                Name = serviceDto.Name,
                Description = serviceDto.Description,
                Price = serviceDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateServiceAsync(service);
            return CreatedAtAction(nameof(GetServiceAsync), new { id = service.Id }, service.AsDto());
        }

        // PUT /services/{id}
        // needs additional parameters { "name" : "" , "description" : "" , "price" : }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateServiceDto serviceDto)
        {
            var existingService = await repository.GetServiceAsync(id);

            if (existingService is null)
            {
                return NotFound();
            }

            Service updatedService = existingService with {
                Name = serviceDto.Name,
                Description = serviceDto.Description,
                Price = serviceDto.Price
            };

            await repository.UpdateServiceAsync(updatedService);

            return NoContent();
        }

        // DELETE /service/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteServiceAsync(Guid id) {
            var existingService = await repository.GetServiceAsync(id);

            if (existingService is null)
            {
                return NotFound();
            }

            await repository.DeleteServiceAsync(id);

            return NoContent();
        }
    }
}