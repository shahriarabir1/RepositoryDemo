using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryDemo.Model;
using RepositoryDemo.Repositories;

namespace RepositoryDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IHomeRepositories _homeRepositories;

        public HomeController(IHomeRepositories homeRepositories) { 
            _homeRepositories = homeRepositories;
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id) { 
            Product a=_homeRepositories.GetProductById(id);
            if(a == null)
            {
                return NotFound("Product Not Found");
            }
            return Ok(a);
        }

        [HttpGet]
        public IActionResult GetAllProduct() 
        { 
            IEnumerable<Product> products = _homeRepositories.GetAllProducts();
            if(products == null)
            {
                return NotFound("No Products Found");
            }
            return Ok(products);
        }

        [HttpGet("byname")]
        public IActionResult GetProductByName([FromQuery] string name)
        {
            var product = _homeRepositories.GetProductByName(name);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product data.");
            }

            Product createdProduct = _homeRepositories.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (product == null || id != product.Id)
            {
                return BadRequest("Invalid product data.");
            }

            try
            {
                var updatedProduct = _homeRepositories.UpdateProduct(product);
                return Ok(updatedProduct);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Product not found.");
            }
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingProduct = _homeRepositories.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }

            _homeRepositories.DeleteProduct(id);
            return NoContent();
        }



    }
}
