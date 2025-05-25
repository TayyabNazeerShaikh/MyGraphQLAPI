// src/MyGraphQLAPI.Domain/Interfaces/IProductRepository.cs
using MyGraphQLAPI.Domain.Entities;

namespace MyGraphQLAPI.Domain.Interfaces
{
    // Interface for data access operations related to Products
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<int> SaveChangesAsync(); // Represents a unit of work concept
    }
}