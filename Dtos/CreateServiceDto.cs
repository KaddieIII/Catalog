using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    // when creating a new service, only name, description and price is needed.
    // program auto-generates id and timestamp
    public record CreateServiceDto{
        [Required] public string Name { get; init; }
        [Required] public string Description { get; init; }
        [Required] [Range(0,1000)] public decimal Price { get; init; }
        [Required] public string Picture { get; init; }
    }
}