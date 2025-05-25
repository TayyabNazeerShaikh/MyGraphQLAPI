// src/MyGraphQLAPI.Application/Services/ProductService.cs
using Microsoft.Extensions.Logging;
using MyGraphQLAPI.Application.Interfaces;
using MyGraphQLAPI.Domain.Entities;
using MyGraphQLAPI.Domain.Interfaces;

namespace MyGraphQLAPI.Application.Services;

// Concrete implementation of the application service
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        _logger.LogInformation("Fetching all products.");
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        _logger.LogInformation("Fetching product with ID: {ProductId}", id);
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            _logger.LogWarning("Product with ID {ProductId} not found.", id);
        }
        return product;
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        _logger.LogInformation("Adding new product: {ProductName}", product.Name);
        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync(); // Persist changes
        _logger.LogInformation("Product added successfully with ID: {ProductId}", product.Id);
        return product;
    }

    public async Task<Product?> UpdateProductAsync(int id, Product updatedProduct)
    {
        _logger.LogInformation("Updating product with ID: {ProductId}", id);
        var existingProduct = await _productRepository.GetByIdAsync(id);

        if (existingProduct == null)
        {
            _logger.LogWarning("Product with ID {ProductId} not found for update.", id);
            return null; // Indicate not found
        }

        // Apply updates (simple mapping, more complex logic may be needed)
        existingProduct.Name = updatedProduct.Name;
        existingProduct.Description = updatedProduct.Description;
        existingProduct.Price = updatedProduct.Price;
        existingProduct.Stock = updatedProduct.Stock;

        await _productRepository.UpdateAsync(existingProduct);
        await _productRepository.SaveChangesAsync(); // Persist changes
        _logger.LogInformation("Product with ID {ProductId} updated successfully.", id);
        return existingProduct;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        _logger.LogInformation("Deleting product with ID: {ProductId}", id);
        var existingProduct = await _productRepository.GetByIdAsync(id);

        if (existingProduct == null)
        {
            _logger.LogWarning("Product with ID {ProductId} not found for deletion.", id);
            return false; // Indicate not found
        }

        await _productRepository.DeleteAsync(id);
        await _productRepository.SaveChangesAsync(); // Persist changes
        _logger.LogInformation("Product with ID {ProductId} deleted successfully.", id);
        return true; // Indicate success
    }
}