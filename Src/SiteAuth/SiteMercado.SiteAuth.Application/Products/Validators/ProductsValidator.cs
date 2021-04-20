using FluentValidation;
using SiteMercado.SiteAuth.Application.Products.Models;

namespace SiteMercado.SiteAuth.Application.Products.Validators
{
    /// <summary>
    /// Products Validator class.
    /// </summary>
    public class ProductsValidator : AbstractValidator<ProductModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsValidator"/> class.
        /// </summary>
        public ProductsValidator()
        {
            RuleFor(prod => prod.Description).NotNull().MinimumLength(3).MaximumLength(254);
            RuleFor(prod => prod.Price).NotNull().GreaterThan(0);
            RuleFor(prod => prod.ImageUrl).NotNull();
            RuleFor(prod => prod.ImageUrl).NotEmpty();
        }
    }
}
