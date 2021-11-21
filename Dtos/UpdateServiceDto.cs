using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    // only name, description and price should be updatable
    public record UpdateServiceDto{
        [Required] public string Name { get; init; }
        [Required] public string Description { get; init; }
        [Required] [Range(0,1000)] public decimal Price { get; init; }
        [Required] public string Picture { get; init; }
        [Required] public string Base64 { get; init; }
    }
}