using CashRegister.Domain.Models;

namespace CashRegister.Infrastructure.Interface
{
    public interface IProductRepository
    {
        bool CreateNewProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        public bool CheckIfProductExists(int id);
        bool Save();
    }
}