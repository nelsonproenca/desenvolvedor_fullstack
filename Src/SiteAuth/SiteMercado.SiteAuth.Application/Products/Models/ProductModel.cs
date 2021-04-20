namespace SiteMercado.SiteAuth.Application.Products.Models
{
    /// <summary>
    /// ProductModel class.
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets imageUrl.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether isDeleted.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
