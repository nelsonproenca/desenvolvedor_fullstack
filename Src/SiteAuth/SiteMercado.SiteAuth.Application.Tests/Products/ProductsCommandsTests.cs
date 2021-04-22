using Microsoft.Extensions.Logging;
using Moq;
using SiteMercado.SiteAuth.Application.Products.Commands;
using SiteMercado.SiteAuth.Application.Products.Models;
using SiteMercado.SiteAuth.Application.Tests.Fakes;
using SiteMercado.SiteAuth.Persistence;
using Xunit;

namespace SiteMercado.SiteAuth.Application.Tests.Products
{
    /// <summary>
    /// ProductsCommandsTests class.
    /// </summary>
    public class ProductsCommandsTests : TestBase
    {
        /// <summary>
        /// Should_Be_Create_NewCampaign_Returns_CommandResult Test.
        /// </summary>
        [Fact]
        public async void Should_Be_Create_NewProduct_Returns_Object()
        {
            using var siteAuthDbContextFactory = new SiteAuthDbContextFactory();

            using (var context = new SiteAuthDbContext(siteAuthDbContextFactory.Options))
            {
                siteAuthDbContextFactory.SeedContextForSqlite(context);
            }

            using (var context = new SiteAuthDbContext(siteAuthDbContextFactory.Options))
            {
                // Arrange
                var campaignModel = new ProductModel()
                {
                    IsDeleted = false,
                    Description = "Product 1",
                    ImageUrl = "http://localhost:3333/images/product1.png",
                    Price = 20
                };

                var logger = new Mock<ILogger<ProductsCommands>>();

                var productsCommands = new ProductsCommands(context, logger.Object, Mapper);

                // Act
                var result = await productsCommands.CreateAsync(campaignModel);

                // Assert
                Assert.NotNull(result);
                Assert.True(result.Id > 0);
            }
        }
    }
}
