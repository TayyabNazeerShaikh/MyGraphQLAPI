// src/MyGraphQLAPI.Application/Interfaces/IProductService.cs
using MyGraphQLAPI.Domain.Entities;

namespace MyGraphQLAPI.Application.Interfaces
{
    // Interface for application-level product operations
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task<Product?> UpdateProductAsync(int id, Product updatedProduct);
        Task<bool> DeleteProductAsync(int id);
        // Potentially add more complex business logic methods here
        // e.g., Task<bool> PurchaseProductAsync(int productId, int quantity);
    }
}