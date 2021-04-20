using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SiteMercado.SiteAuth.Application.Products.Models;
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
        public Task<IEnumerable<ProductModel>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ProductModel> GetOne(ProductModel product)
        {
            throw new System.NotImplementedException();
        }
    }
}
