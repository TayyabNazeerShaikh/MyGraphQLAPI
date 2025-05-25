// src/MyGraphQLAPI.API/GraphQL/Mutations/Mutation.cs

using MyGraphQLAPI.Application.Interfaces;
using MyGraphQLAPI.Domain.Entities;
using MyGraphQLAPI.API.GraphQL.Inputs;
using MyGraphQLAPI.API.Payloads;

// Remove the [ExtendObjectType] attribute
// [ExtendObjectType(Name = "Mutation")]
public class Mutation // This class defines the root Mutation type
{
    // Example Mutation 1: Add a new product
    public async Task<AddProductPayload> AddProduct(AddProductInput input, [Service] IProductService productService)
    {
        var product = new Product
        {
            Name = input.Name,
            Description = input.Description,
            Price = input.Price,
            Stock = input.Stock
        };

        // Consider more specific exception handling here if business rules can be violated
        var addedProduct = await productService.AddProductAsync(product);
        return new AddProductPayload(addedProduct);
    }

    // Example Mutation 2: Update an existing product
    public async Task<UpdateProductPayload> UpdateProduct(UpdateProductInput input, [Service] IProductService productService)
    {
         var updatedProduct = new Product
        {
            Id = input.Id,
            Name = input.Name,
            Description = input.Description,
            Price = input.Price,
            Stock = input.Stock
        };

        var result = await productService.UpdateProductAsync(input.Id, updatedProduct);

        if (result == null)
        {
             // Throwing here lets the Hot Chocolate error filter handle it
             throw new Exception($"Product with ID {input.Id} not found.");
             // Or you could return a payload with error information if preferred
        }

        return new UpdateProductPayload(result);
    }

     // Example Mutation 3: Delete a product
    public async Task<DeleteProductPayload> DeleteProduct(int id, [Service] IProductService productService)
    {
        var success = await productService.DeleteProductAsync(id);

        if (!success)
        {
             // Throwing here lets the Hot Chocolate error filter handle it
             throw new Exception($"Product with ID {id} not found.");
             // Or you could return payload with error information
        }

        return new DeleteProductPayload(true);
    }
}