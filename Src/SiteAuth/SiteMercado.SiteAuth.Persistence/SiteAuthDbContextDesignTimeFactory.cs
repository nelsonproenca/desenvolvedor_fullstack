using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SiteMercado.SiteAuth.Persistence
{
    /// <summary>
    /// SiteAuth dbcontext design time factory class.
    /// </summary>
    public class SiteAuthDbContextDesignTimeFactory
    {
        private const string ConnectionName = "SiteAuthConnectionString";

        /// <summary>
        /// Create DbContext.
        /// </summary>
        /// <param name="args">array args.</param>
        /// <returns>EmailDbContex.</returns>
        public SiteAuthDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SiteAuthDbContext>();

            string connString = configuration.GetConnectionString(ConnectionName);

            optionsBuilder.UseSqlServer(connString);

            return new SiteAuthDbContext(optionsBuilder.Options, configuration);
        }
    }
}
