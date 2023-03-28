using CashRegister.Domain.Models;
using CashRegister.Infrastructure.Context;
using CashRegister.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace CashRegister.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CashRegisterDBContext _dbContext;

        public ProductRepository(CashRegisterDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateNewProduct(Product product)
        {
            _dbContext.Products.Add(product);
            return Save();
        }

        public bool UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
            return Save();
        }

        public bool DeleteProduct(Product product)
        {
            _dbContext.Remove(product);
            return Save();
        }

        public async Task<Product> GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public bool CheckIfProductExists(int id)
        {
            var result = _dbContext.Products.Any(p => p.Id == id);
            return result;
        }
    }
}
