// src/MyGraphQLAPI.API/GraphQL/Queries/Query.cs
using HotChocolate.Types;
using MyGraphQLAPI.Application.Interfaces;
using MyGraphQLAPI.Domain.Entities;
using MyGraphQLAPI.API.GraphQL.Types;

// Remove the [ExtendObjectType] attribute
// [ExtendObjectType(Name = "Query")]
public class Query // This class defines the root Query type
{
    // Example Query 1: Get all products
    [UseSorting] // Adds sorting capabilities
    [UseFiltering] // Adds filtering capabilities
    public async Task<IEnumerable<Product>> GetProducts([Service] IProductService productService)
    {
        return await productService.GetAllProductsAsync();
    }

    // Example Query 2: Get product by ID
    public async Task<Product?> GetProductById(int id, [Service] IProductService productService)
    {
        return await productService.GetProductByIdAsync(id);
    }
}