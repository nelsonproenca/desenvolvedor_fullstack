using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiteMercado.SiteAuth.Application.Products.Models;
using SiteMercado.SiteAuth.Domain.Entities;
using SiteMercado.SiteAuth.Persistence;

namespace SiteMercado.SiteAuth.Application.Products.Queries
{
    /// <summary>
    /// ProductsQueries Class.
    /// </summary>
    public class ProductsQueries : IProductsQueries
    {
        private readonly ISiteAuthDbContext context;
        private readonly ILogger<ProductsQueries> logger;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsQueries"/> class.
        /// </summary>
        /// <param name="context">SiteAuth dbcontext.</param>
        /// <param name="logger">logger.</param>
        /// <param name="mapper">mapper.</param>
        public ProductsQueries(ISiteAuthDbContext context, ILogger<ProductsQueries> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            IQueryable<Product> products = context.Products.AsQueryable();

            var result = await products
                .ProjectTo<ProductModel>(mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        /// <inheritdoc/>
        public async Task<ProductModel> GetOneAsync(int productId)
        {
            var product = await context.Products?.FirstOrDefaultAsync(eml => eml.Id == productId);

            if (product == null)
            {
                return null;
            }

            var result = mapper.Map<ProductModel>(product);

            return result;
        }
    }
}
