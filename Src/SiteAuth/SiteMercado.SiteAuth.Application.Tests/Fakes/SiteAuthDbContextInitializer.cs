using System.Collections.Generic;
using System.Collections.ObjectModel;
using SiteMercado.SiteAuth.Persistence;

namespace SiteMercado.SiteAuth.Application.Tests.Fakes
{
    /// <summary>
    /// SiteAuthDbContextInitializer class.
    /// </summary>
    public static class SiteAuthDbContextInitializer
	{
		/// <summary>
		/// Seed method.
		/// </summary>
		/// <param name="context">context.</param>
		public static void Seed(this SiteAuthDbContext context)
		{
			var products = SeedProducts();
			context.Products.AddRange(products);
			context.SaveChanges();
		}

		private static ICollection<Domain.Entities.Product> SeedProducts()
		{
			var result = new Collection<Domain.Entities.Product>()
			{
				new Domain.Entities.Product()
				{
					Id = 1, IsDeleted = false, Description = "produto1", ImageUrl = "http://localhost/imagem1.png", Price = 10
				},
				new Domain.Entities.Product()
				{
					Id = 2, IsDeleted = false, Description = "produto2", ImageUrl = "http://localhost/imagem2.png", Price = 20
				},
				new Domain.Entities.Product()
				{
					Id = 3, IsDeleted = false, Description = "produto3", ImageUrl = "http://localhost/imagem3.png", Price = 30
				},
				new Domain.Entities.Product()
				{
					Id = 4, IsDeleted = false, Description = "produto4", ImageUrl = "http://localhost/imagem4.png", Price = 40
				}
			};

			return result;
		}
	}
}
