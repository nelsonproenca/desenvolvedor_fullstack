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
        Task<ProductModel> Create(ProductModel product);

        /// <summary>
        /// Delete a product.
        /// </summary>
        /// <param name="productId">Product identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<bool> Delete(int productId);

        /// <summary>
        /// Update a product.
        /// </summary>
        /// <param name="updatedProduct">ProductModel object.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<bool> Update(ProductModel updatedProduct);
    }
}
