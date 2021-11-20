using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{
    public static class Extensions
    {
        public static ServiceDto AsDto(this Service service)
        {
            return new ServiceDto{
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
                CreatedDate = service.CreatedDate
            };
        }
    }
}