using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteMercado.SiteAuth.Application.Products.Commands;
using SiteMercado.SiteAuth.Application.Products.Models;
using SiteMercado.SiteAuth.Application.Products.Queries;
using SiteMercado.SiteAuth.WebApi.Filters;

namespace SiteMercado.SiteAuth.WebApi.Controllers
{
    /// <summary>
    /// SiteAuths Controller class.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ErrorHandler]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsCommands productsCommands;
        private readonly IProductsQueries productsQueries;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productsCommands">products Commands.</param>
        /// <param name="productsQueries">products Queries.</param>
        public ProductsController(IProductsCommands productsCommands, IProductsQueries productsQueries)
        {
            this.productsCommands = productsCommands;
            this.productsQueries = productsQueries;
        }

        /// <summary>
        /// Add new product.
        /// </summary>
        /// <param name="product">new product.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductModel product)
        {
            var result = await productsCommands.CreateAsync(product);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        /// <summary>
        /// Update product data.
        /// </summary>
        /// <param name="product">product to update.</param>
        /// <param name="productId">product id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductModel product, int productId)
        {
            var result = await productsCommands.UpdateAsync(productId, product);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete a product logically.
        /// </summary>
        /// <param name="productId">product id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPut]
        public async Task<IActionResult> Delete(int productId)
        {
            var result = await productsCommands.DeleteAsync(productId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        /// <summary>
        /// Get a product.
        /// </summary>
        /// <param name="productId">product id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetOne(int productId)
        {
            var result = await productsQueries.GetOneAsync(productId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IActionResult> GetAll()
        {
            var result = await productsQueries.GetAllAsync();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
