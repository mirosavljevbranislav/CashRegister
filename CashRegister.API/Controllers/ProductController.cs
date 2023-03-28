using AutoMapper;
using CashRegister.API.Dto;
using CashRegister.Domain.Models;
using CashRegister.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepostirory, IMapper mapper)
        {
            _productRepository = productRepostirory;
            _mapper = mapper; 
        }

        [HttpGet("getAll")]
        public IActionResult GetAllProductsRequest()
        {
            var listOfProducts = _productRepository.GetAllProducts();
            return listOfProducts != null ? Ok(listOfProducts) : NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            return product == null ? NotFound($"Product with id: {id} not found.") : Ok(product);
        }

        [HttpPost()]
        public IActionResult AddNewProduct(Product product)
        {
            var productResult = _productRepository.CreateNewProduct(product: product);
            return productResult ? Ok("Product added successfuly") : BadRequest("Something went wrong");
        }

        [HttpPut("{id}")]
        public IActionResult EditProduct(int id, [FromBody] ProductDto productDto)
        {
            if (!_productRepository.CheckIfProductExists(id: id))
                return NotFound($"Product with id: {id} not found.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mappedProduct = _mapper.Map<Product>(productDto);
            var updateResult = _productRepository.UpdateProduct(product: mappedProduct);
            return updateResult ? Ok("Product updated successfuly") : BadRequest("Something went wrong, product not updated");
        }

        //[HttpDelete("{id}")]
        //public IActionResult DeleteProduct(int id)
        //{
        //    if (!_productRepository.CheckIfProductExists(id: id))
        //        return NotFound($"Product with id: {id} not found.");
        //    var product = _productRepository.GetProductById(id: id);
        //    var deletedResult =  _productRepository.DeleteProduct(product: product);
        //    return deletedResult ? Ok("Product successfuly deleted.") : BadRequest("Somethign went wrong. product not deleted");
        //}
    }
}
