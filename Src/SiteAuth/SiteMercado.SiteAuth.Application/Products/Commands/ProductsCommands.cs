using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiteMercado.SiteAuth.Application.Products.Models;
using SiteMercado.SiteAuth.Application.Products.Validators;
using SiteMercado.SiteAuth.Domain.Entities;
using SiteMercado.SiteAuth.Persistence;

namespace SiteMercado.SiteAuth.Application.Products.Commands
{
    /// <summary>
    /// Products Commands class. 
    /// </summary>
    public class ProductsCommands : IProductsCommands
    {
        private readonly ISiteAuthDbContext context;
        private readonly ILogger<ProductsCommands> logger;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsCommands"/> class.
        /// </summary>
        /// <param name="context">SiteAuth dbcontext.</param>
        /// <param name="logger">logger.</param>
        /// <param name="mapper">mapper.</param>
        public ProductsCommands(ISiteAuthDbContext context, ILogger<ProductsCommands> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<ProductModel> CreateAsync(ProductModel product)
        {            
            await Utils.Utils.ValidateCommandAsync(new ProductModelValidator(), product);

            var newProduct = mapper.Map<Product>(product);

            context.Products.Add(newProduct);

            await context.SaveChangesAsync();

            var model = mapper.Map<ProductModel>(newProduct);

            return model;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(int productId)
        {
            var productSearch = await context.Products?.SingleOrDefaultAsync(prv => prv.Id == productId);

            productSearch.IsDeleted = true;

            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        /// <inheritdoc/>
        public async Task<ProductModel> UpdateAsync(int productId, ProductModel updatedProduct)
        {
            await Utils.Utils.ValidateCommandAsync(new ProductModelValidator(), updatedProduct);

            var productSearch = await context.Products?.SingleOrDefaultAsync(prod => prod.Id == productId);

            if (productSearch == null)
            {
                return null;
            }

            var product = mapper.Map(updatedProduct, productSearch);

            await context.SaveChangesAsync();

            var model = mapper.Map<ProductModel>(product);

            return model;
        }
    }
}