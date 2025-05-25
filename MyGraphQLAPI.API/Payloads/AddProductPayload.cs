using MyGraphQLAPI.Domain.Entities;

namespace MyGraphQLAPI.API.Payloads;

// Payload type for the AddProduct mutation result
// Often includes the result entity and potentially error information
public class AddProductPayload
{
    public AddProductPayload(Product product)
    {
        Product = product;
        // Errors = null; // Assume success if product is not null
    }

    public Product Product { get; }

    // Optional: Add a list of errors here if mutations can partially fail or have business rule errors
    // public IReadOnlyList<string> Errors { get; }
}