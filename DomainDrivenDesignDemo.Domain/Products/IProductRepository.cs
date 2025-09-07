namespace DomainDrivenDesignDemo.Domain.Products;

public interface IProductRepository
{
    Task CreateAsync(string name, int quantity, decimal amount, string curreny, Guid categoryId, CancellationToken cancellationToken = default);
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default);
}