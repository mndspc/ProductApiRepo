using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Repository;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInfoController : ControllerBase
    {
        private readonly IProductRepo<Product> _productRepo;
        public ProductInfoController(IProductRepo<Product> productRepo)
        {
            this._productRepo = productRepo;
        }

        [HttpGet("GetAll")]
        [Produces("application/json")]
        public IActionResult GetAllProducts()
        {
            var products = _productRepo.GetAllProduct();
            if (products is not null)
            {
                return Ok(products);
            }
            else
            {
                return NotFound("No products found.");
            }

        }

        [HttpGet("GetById/{id?}")]
        [Produces("application/json")]
        public IActionResult GetProductById(int? id)
        {
            var product = _productRepo.GetProductById(id);
            if (product is not null)
            {
                return Created(HttpContext.Request.Path, product);
            }
            else
            {
                return NotFound($"Product with Id: {id} not found.");
            }
        }

        [HttpPost("AddProduct")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (product is not null)
            {
                var addedProduct = _productRepo.AddProduct(product);
                return Created(HttpContext.Request.Path, addedProduct);
            }
            else
            {
                return BadRequest("Product data is null.");
            }
        }

        [HttpPut("UpdateProduct/{id?}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult UpdateProduct(int? id, [FromBody] Product product)
        {
            var existingProduct = _productRepo.GetProductById(id);
            if (existingProduct is not null && product is not null)
            {
                var updatedProduct = _productRepo.UpdateProduct(product);
                return Created(HttpContext.Request.Path, updatedProduct);
            }
            else
            {
                return NotFound($"Product with Id: {id} not found or product data is null.");
            }
        }

        [HttpDelete("DeleteProduct")]
        [Produces("application/json")]
        public IActionResult DeleteProduct(int? id)
        {
            var existingProduct = _productRepo.GetProductById(id);
            if (existingProduct is not null)
            {
                _productRepo.RemoveProduct(id);
                return Ok($"Product with Id: {id} deleted successfully.");
            }
            else
            {
                return NotFound($"Product with Id: {id} not found.");
            }
        }
    }
}
