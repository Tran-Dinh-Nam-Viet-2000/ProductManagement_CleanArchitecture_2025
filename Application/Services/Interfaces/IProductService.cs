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
    }
}
