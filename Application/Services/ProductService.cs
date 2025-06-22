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

        #region CRUD Product by linq method syntax
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

        public async Task CreateProduct(CreateProductDto product)
        {
            await _productRepository.CreateProductAsync(_mapper.Map<Product>(product));
        }

        public async Task UpdateProduct(UpdateProductDto product)
        {
            await _productRepository.UpdateProductAsync(_mapper.Map<Product>(product));
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
        #endregion

        #region Get product by linq query syntax
        public IEnumerable<ProductDto> GetAllProduct_LinqQuery()
        {
            var datas = _productRepository.GetAll_LinqQuery();
            return _mapper.Map<IEnumerable<ProductDto>>(datas);
        }

        public ProductDto GetProductById_LinqQuery(int id)
        {
            var data = _productRepository.GetProductById_LinqQuery(id);
            return _mapper.Map<ProductDto>(data);
        }
        #endregion

        #region CRUD Product by query syntax database
        public IEnumerable<ProductDto> GetAllProduct_SqlQueryRaw()
        {
            var datas = _productRepository.GetAll_LinqQuery();
            return _mapper.Map<IEnumerable<ProductDto>>(datas);
        }

        public ProductDto GetProductById_SqlQueryRaw(int id)
        {
            var data = _productRepository.GetProductById_LinqQuery(id);
            return _mapper.Map<ProductDto>(data);
        }

        public int CreateProduct_ExcuteSqlRaw(CreateProductDto product)
        {
            return _productRepository.CreateProduct_ExcuteSqlRaw(_mapper.Map<Product>(product));
        }

        public int UpdateProduct_ExcuteSqlRaw(UpdateProductDto product)
        {
            return _productRepository.UpdateProduct_ExcuteSqlRaw(_mapper.Map<Product>(product));
        }

        public int DeleteProduct_ExcuteSqlRaw(int id)
        {
            return _productRepository.DeleteProduct_ExcuteSqlRaw(id);
        }
        #endregion
    }
}
