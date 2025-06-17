using Application.Dtos.Product;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task CreateProduct(CreateProductDto product)
        {
            await _productRepository.CreateProductAsync(_mapper.Map<Product>(product));
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }

        public async Task<List<ProductDto>> GetAllProduct()
        {
            var datas = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(datas);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) throw new ArgumentNullException("The product was not found");
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProduct(UpdateProductDto product)
        {
            await _productRepository.UpdateProductAsync(_mapper.Map<Product>(product));
        }
    }
}
