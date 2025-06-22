using Domain.Entity;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        // Use linq method syntax
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);

        // Use linq query syntax
        IEnumerable<Product> GetAll_LinqQuery();
        Product? GetProductById_LinqQuery(int id);

        // Use query syntax database
        // SqlQueryRaw for 'SELECT' syntax
        // ExcuteSqlRaw for 'CREATE, UPDATE, DELETE' syntax
        IEnumerable<Product> GetAll_SqlQueryRaw();
        Product? GetProductById_SqlQueryRaw(int id);
        int CreateProduct_ExcuteSqlRaw(Product product);
        int UpdateProduct_ExcuteSqlRaw(Product product);
        int DeleteProduct_ExcuteSqlRaw(int id);
    }
}
