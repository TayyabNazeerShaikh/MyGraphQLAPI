// src/MyGraphQLAPI.Infrastructure/Repositories/ProductRepository.cs
using Microsoft.EntityFrameworkCore;
using MyGraphQLAPI.Domain.Entities;
using MyGraphQLAPI.Domain.Interfaces;
using MyGraphQLAPI.Infrastructure.Persistence;

namespace MyGraphQLAPI.Infrastructure.Repositories;

// Concrete implementation of the repository interface
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        // EF Core tracks changes, so just ensure it's attached/tracked
        _context.Products.Update(product);
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
        }
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}