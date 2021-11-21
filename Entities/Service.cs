using System;

namespace Catalog.Entities
{
    // pattern for a service
    public record Service
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public string Picture { get; init; }
        public string Base64 { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}