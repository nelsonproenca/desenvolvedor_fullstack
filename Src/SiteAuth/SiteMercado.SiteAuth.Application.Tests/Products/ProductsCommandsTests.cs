using System.Linq;
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
        /// Should_Be_Create_NewProduct_Returns_Object Test.
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
                var productModel = new ProductModel()
                {
                    IsDeleted = false,
                    Description = "Product 1",
                    ImageUrl = "http://localhost:3333/images/product1.png",
                    Price = 20
                };

                var logger = new Mock<ILogger<ProductsCommands>>();

                var productsCommands = new ProductsCommands(context, logger.Object, Mapper);

                // Act
                var result = await productsCommands.CreateAsync(productModel);

                // Assert
                Assert.NotNull(result);
                Assert.True(result.Id > 0);
            }
        }

        /// <summary>
        /// Should_Be_Update_Product_Returns_Object Test.
        /// </summary>
        [Fact]
        public async void Should_Be_Update_Product_Returns_Object()
        {
            using var siteAuthDbContextFactory = new SiteAuthDbContextFactory();

            using (var context = new SiteAuthDbContext(siteAuthDbContextFactory.Options))
            {
                siteAuthDbContextFactory.SeedContextForSqlite(context);
            }

            using (var context = new SiteAuthDbContext(siteAuthDbContextFactory.Options))
            {
                // Arrange
                var productModel = new ProductModel()
                {
                    IsDeleted = false,
                    Description = "Product 121212",
                    ImageUrl = "http://localhost:3333/images/product121212.png",
                    Price = 1200
                };

                int productId = 1;

                var logger = new Mock<ILogger<ProductsCommands>>();

                var productsCommands = new ProductsCommands(context, logger.Object, Mapper);

                // Act
                var result = await productsCommands.UpdateAsync(productId, productModel);

                // Assert
                Assert.NotNull(result);
                Assert.True(result.Description == productModel.Description);
            }
        }

        /// <summary>
        /// Should_Be_Delete_Product_Returns_Success Test.
        /// </summary>
        [Fact]
        public async void Should_Be_Delete_Product_Returns_Success()
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

                var logger = new Mock<ILogger<ProductsCommands>>();

                var productsCommands = new ProductsCommands(context, logger.Object, Mapper);

                // Act
                var result = await productsCommands.DeleteAsync(productId);

                // Assert
                Assert.True(result);

                var current = Mapper.Map<ProductModel>(context.Products.FirstOrDefault(x => x.Id == productId));

                Assert.Null(current);
            }
        }
    }
}
