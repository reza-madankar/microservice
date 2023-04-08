using Catalog.Api.Entities;
using Catalog.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : Controller
    {
        #region Constructor

        private readonly IProductRepository _productRepo;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductRepository productRepo, ILogger<CatalogController> logger)
        {
            _productRepo = productRepo;
            _logger = logger;
        }


        #endregion

        #region Get Product

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepo.GetProducts();
            return Ok(products);
        }


        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var products = await _productRepo.GetProduct(id);

            if (products == null)
            {
                _logger.LogError($"Product with id: {id} is not found.");
                return NotFound();
            }

            return Ok(products);
        }


        [HttpGet("[action]/{category}")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCatategory(string category)
        {
            var products = await _productRepo.GetProductsByCatategory(category);
            return Ok(products);
        }

        [HttpGet("[action]/{name}")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByName(string name)
        {
            var products = await _productRepo.GetProductsByName(name);
            return Ok(products);
        }

        #endregion

        #region Create Product

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> CreateProduct([FromBody] Product product)
        {
            await _productRepo.CreateProduct(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        #endregion

        #region Update Product

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> UpdateProduct([FromBody] Product product)
        {
            return Ok(await _productRepo.UpdateProduct(product));
        }

        #endregion

        #region Remove Product

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> DeleteProduct(string id)
        {
            return Ok(await _productRepo.DeleteProduct(id));
        }

        #endregion

    }
}
