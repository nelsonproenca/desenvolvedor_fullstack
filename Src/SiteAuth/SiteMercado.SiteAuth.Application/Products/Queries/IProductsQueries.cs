using System.Collections.Generic;
using System.Threading.Tasks;
using SiteMercado.SiteAuth.Application.Products.Models;

namespace SiteMercado.SiteAuth.Application.Products.Queries
{
    /// <summary>
    /// Interface ProductsQueries.
    /// </summary>
    public interface IProductsQueries
    {
        /// <summary>
        /// Get one product.
        /// </summary>
        /// <param name="product">Product model.</param>
        /// <returns>A <see cref="Task"/> and <see cref="ProductModel"/> representing the asynchronous operation.</returns>
        Task<ProductModel> GetOne(ProductModel product);

        /// <summary>
        /// Get All products.
        /// </summary>
        /// <returns>A <see cref="Task"/> and <see cref="ProductModel"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<ProductModel>> GetAll();
    }
}