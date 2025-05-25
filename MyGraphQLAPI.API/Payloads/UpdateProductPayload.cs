using MyGraphQLAPI.Domain.Entities;

namespace MyGraphQLAPI.API.Payloads;

public class UpdateProductPayload
{
    public UpdateProductPayload(Product? product /*, IReadOnlyList<string>? errors = null */)
    {
        Product = product;
        // Errors = errors;
    }

    public Product? Product { get; }
    // public IReadOnlyList<string>? Errors { get; }
}