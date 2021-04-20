using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiteMercado.SiteAuth.Application.Products.Commands;
using SiteMercado.SiteAuth.Application.Products.Mappings;
using SiteMercado.SiteAuth.Application.Products.Queries;
using SiteMercado.SiteAuth.Persistence;

namespace SiteMercado.SiteAuth.Ioc
{
    /// <summary>
    /// DependencyInjectionContainer class
    /// </summary>
    public class DependencyInjectionContainer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        public static void ServiceIoc(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IProductsCommands, ProductsCommands>();

            services.AddScoped<IProductsQueries, ProductsQueries>();

            services.AddDbContext<ISiteAuthDbContext, SiteAuthDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SiteAuthConnectionString")), ServiceLifetime.Scoped);

            services.AddAutoMapper(new[]
            {
                typeof(ProductsMappings),
            });
        }
    }
}
