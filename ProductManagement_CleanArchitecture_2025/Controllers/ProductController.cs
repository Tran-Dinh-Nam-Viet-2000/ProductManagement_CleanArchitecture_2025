using Application.Dtos.Product;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement_CleanArchitecture_2025.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Get all product")]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productService.GetAllProduct();
            return Ok(products);
        }

        [HttpGet("Get a product")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPost("Create a product")]
        public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
        {
            await _productService.CreateProduct(productDto);
            return Ok();
        }

        [HttpPost("Update a product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto productDto)
        {
            await _productService.UpdateProduct(productDto);
            return Ok();
        }

        [HttpDelete("Delete a product")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok();
        }

        [HttpGet("Get all product by linq query")]
        public IActionResult GetAllProductLinqQuery()
        {
            return Ok(_productService.GetAllProduct_LinqQuery());
        }

        [HttpGet("Get product by linq query")]
        public IActionResult GetProductByIdLinqQuery(int id)
        {
            return Ok(_productService.GetProductById_LinqQuery(id));
        }

        [HttpGet("Get all product by query syntax database")]
        public IActionResult GetAllProductQuerySyntaxDatabase()
        {
            return Ok(_productService.GetAllProduct_SqlQueryRaw());
        }

        [HttpGet("Get product by query syntax database")]
        public IActionResult GetProductQuerySyntaxDatabase(int id)
        {
            return Ok(_productService.GetProductById_SqlQueryRaw(id));
        }

        [HttpPost("Create product by query syntax database")]
        public IActionResult CreateProductQuerySyntaxDatabase(CreateProductDto product)
        {
            var create = _productService.CreateProduct_ExcuteSqlRaw(product);
            return Ok(create);
        }

        [HttpPost("Update product by query syntax database")]
        public IActionResult UpdateProductQuerySyntaxDatabase(UpdateProductDto product)
        {
            var create = _productService.UpdateProduct_ExcuteSqlRaw(product);
            return Ok(create);
        }

        [HttpDelete("Delete product by query syntax database")]
        public IActionResult CreateProductQuerySyntaxDatabase(int id)
        {
            var create = _productService.DeleteProduct_ExcuteSqlRaw(id);
            return Ok(create);
        }
    }
}
