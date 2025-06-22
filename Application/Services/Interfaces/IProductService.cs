using Application.Dtos.Product;

namespace Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProduct();
        Task<ProductDto> GetProductById(int id);
        Task CreateProduct(CreateProductDto product);
        Task UpdateProduct(UpdateProductDto product);
        Task DeleteProduct(int id);

        IEnumerable<ProductDto> GetAllProduct_LinqQuery();
        ProductDto GetProductById_LinqQuery(int id);
        
        IEnumerable<ProductDto> GetAllProduct_SqlQueryRaw();
        ProductDto GetProductById_SqlQueryRaw(int id);
        int CreateProduct_ExcuteSqlRaw(CreateProductDto product);
        int UpdateProduct_ExcuteSqlRaw(UpdateProductDto product);
        int DeleteProduct_ExcuteSqlRaw(int id);
    }
}
