using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net.WebSockets;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Use linq method syntax
        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task CreateProductAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var queryData = await _dbContext.Products.FirstOrDefaultAsync(n => n.Id == id);
            if (queryData != null)
            {
                _dbContext.Products.Remove(queryData);
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion

        #region Use linq query syntax
        public IEnumerable<Product> GetAll_LinqQuery()
        {
            var data = from p in _dbContext.Products
                       where p.ProductName != null
                       select p;
            return data;
        }

        public Product? GetProductById_LinqQuery(int id)
        {
            var product = (from p in _dbContext.Products
                          where p.Id == id
                          select p).FirstOrDefault();
            return product;
        }
        #endregion

        #region Use query syntax database
        public IEnumerable<Product> GetAll_SqlQueryRaw()
        {
            return _dbContext.Database.SqlQueryRaw<Product>("SELECT * FROM Product");
        }

        public Product? GetProductById_SqlQueryRaw(int id)
        {
            return _dbContext.Database.SqlQueryRaw<Product>("SELECT * FROM Product WHERE Id = {0}", id).FirstOrDefault();
        }

        public int CreateProduct_ExcuteSqlRaw(Product product)
        {
            var sql = "INSERT INTO Product(ProductName, Description) VALUES({0}, {1})";
            var createData = _dbContext.Database.ExecuteSqlRaw(sql, product.ProductName, product.Description);
            return createData;
        }

        public int UpdateProduct_ExcuteSqlRaw(Product product)
        {
            var sql = "UPDATE Product " +
                "SET ProductName = {0}, Description = {1} " +
                "WHERE Id = {2}";
            var updateData = _dbContext.Database.ExecuteSqlRaw(sql, product.ProductName, product.Description, product.Id);
            return updateData;
        }

        public int DeleteProduct_ExcuteSqlRaw(int id)
        {
            var sql = "DELETE FROM Product WHERE Id = {0}";
            var deleteData = _dbContext.Database.ExecuteSqlRaw(sql, id);
            return deleteData;
        }
        #endregion
    }
}
