using CashRegister.API.Dto;
using CashRegister.Domain.Models;
using CashRegister.Infrastructure.Context;
using CashRegister.Infrastructure.Interface;
using CashRegister.Infrastructure.Repositories;
using Moq;

namespace CashRegisterTests
{
    public class ProductRepositoryTests
    {
        private readonly ProductRepository _repositoryTests;
        private readonly Mock<IProductRepository> _productRepoMock = new Mock<IProductRepository>();
        private readonly Mock<CashRegisterDBContext> _dbMock = new Mock<CashRegisterDBContext>();

        public ProductRepositoryTests()
        {
            _repositoryTests = new ProductRepository(_dbMock.Object);

        }
        [Fact]
        public async void GetProductById_SuccessfulyFinds_ReturnsProduct()
        {
            //Arrange
            var id = 1;
            var productName = "TestProduct";
            var productPrice = 100;
            var product = new Product
            {
                Id = id,
                Name = productName,
                Price = productPrice
            };
            _productRepoMock.Setup(x => x.GetProductById(id)).Returns(product);

            //Act
            var productResult = _repositoryTests.GetProductById(id);

            //Assert
            Assert.Equal(id, productResult.Id);
            Assert.Equal(productName, productResult.Name);
            Assert.Equal(productPrice, productResult.Price);
        }
    }
}