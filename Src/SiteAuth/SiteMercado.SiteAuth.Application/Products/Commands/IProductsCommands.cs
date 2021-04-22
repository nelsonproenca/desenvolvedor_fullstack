using System.Threading.Tasks;
using SiteMercado.SiteAuth.Application.Products.Models;

namespace SiteMercado.SiteAuth.Application.Products.Commands
{
    /// <summary>
    /// Interface Products Commands.
    /// </summary>
    public interface IProductsCommands
    {
        /// <summary>
        /// Create new product.
        /// </summary>
        /// <param name="product">ProductModel object.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<ProductModel> CreateAsync(ProductModel product);

        /// <summary>
        /// Delete a product.
        /// </summary>
        /// <param name="productId">Product identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<bool> DeleteAsync(int productId);

        /// <summary>
        /// Update a product.
        /// </summary>
        /// <param name="productId">product Id.</param>
        /// <param name="updatedProduct">ProductModel object.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<ProductModel> UpdateAsync(int productId, ProductModel updatedProduct);
    }
}
