using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
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
        public Task<bool> Delete(int productId)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<bool> Update(ProductModel updatedProduct)
        {
            throw new System.NotImplementedException();
        }
    }
}
