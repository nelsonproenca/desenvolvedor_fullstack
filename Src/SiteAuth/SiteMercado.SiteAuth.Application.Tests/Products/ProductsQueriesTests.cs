using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using SiteMercado.SiteAuth.Application.Products.Queries;
using SiteMercado.SiteAuth.Application.Tests.Fakes;
using SiteMercado.SiteAuth.Persistence;
using Xunit;

namespace SiteMercado.SiteAuth.Application.Tests.Products
{
    /// <summary>
    /// ProductsQueriesTests class.
    /// </summary>
    public class ProductsQueriesTests : TestBase
    {
        /// <summary>
        /// Should_Be_Get_One_Product_Returns_Product Test.
        /// </summary>
        [Fact]
        public async void Should_Be_Get_One_Product_Returns_Product()
        {
            using var siteAuthDbContextFactory = new SiteAuthDbContextFactory();

            using (var context = new SiteAuthDbContext(siteAuthDbContextFactory.Options))
            {
                siteAuthDbContextFactory.SeedContextForSqlite(context);
            }

            using (var context = new SiteAuthDbContext(siteAuthDbContextFactory.Options))
            {
                // Arrange
                int productId = 1;

                var logger = new Mock<ILogger<ProductsQueries>>();

                var productsQueries = new ProductsQueries(context, logger.Object, Mapper);

                // Act
                var result = await productsQueries.GetOneAsync(productId);

                // Assert
                Assert.NotNull(result);
                Assert.True(result.Id == productId);
            }
        }

        /// <summary>
        /// Should_Be_Get_Products_Returns_List Test.
        /// </summary>
        [Fact]
        public async void Should_Be_Get_Products_Returns_List()
        {
            using var siteAuthDbContextFactory = new SiteAuthDbContextFactory();

            using (var context = new SiteAuthDbContext(siteAuthDbContextFactory.Options))
            {
                siteAuthDbContextFactory.SeedContextForSqlite(context);
            }

            using (var context = new SiteAuthDbContext(siteAuthDbContextFactory.Options))
            {
                // Arrange
                var logger = new Mock<ILogger<ProductsQueries>>();

                var productsQueries = new ProductsQueries(context, logger.Object, Mapper);

                // Act
                var result = await productsQueries.GetAllAsync();

                // Assert
                Assert.NotNull(result);
                Assert.True(result.ToList().Count > 0);
            }
        }
    }
}
