using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;
using Catalog.Repositories;
using Catalog.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http;

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

        // GET /services/{id}/image
        [HttpGet("{id}/image")]
        public async Task<ActionResult<ServiceDto>> GetImageAsync(Guid id)
        {
            
            var service = await repository.GetServiceAsync(id);

            if (service is null)
            {
                return NotFound();
            }

            string path = Directory.GetCurrentDirectory();
            string picture = path + "\\Resources\\" + service.Picture;
            return PhysicalFile(@picture, "image/jpg");
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
                Picture = serviceDto.Picture,
                Base64 = serviceDto.Base64,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateServiceAsync(service);

            string path = Directory.GetCurrentDirectory();
            string picture = path + "\\Resources\\" + service.Picture;

            System.IO.File.WriteAllBytes(@picture, Convert.FromBase64String(service.Base64));

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
                Price = serviceDto.Price,
                Picture = serviceDto.Picture,
                Base64 = serviceDto.Base64
            };

            await repository.UpdateServiceAsync(updatedService);

            if (updatedService.Base64 != null){
                string path = Directory.GetCurrentDirectory();
                string picture = path + "\\Resources\\" + updatedService.Picture;

                System.IO.File.WriteAllBytes(@picture, Convert.FromBase64String(updatedService.Base64));
            }

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