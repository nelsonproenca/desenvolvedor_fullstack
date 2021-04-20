using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SiteMercado.SiteAuth.Domain.Entities;

namespace SiteMercado.SiteAuth.Persistence
{
    /// <summary>
    /// Interface SiteAuth DbContext.
    /// </summary>
    public interface ISiteAuthDbContext
    {
        /// <summary>
        /// Gets access to the database infrastructure layer.
        /// </summary>
        DatabaseFacade Database { get; }

        /// <summary>
        /// Gets or sets products.
        /// </summary>
        DbSet<Product> Products { get; set; }

        /// <summary>
        /// Save all changes.
        /// </summary>
        /// <returns>The number of itens affecteds.</returns>
        int SaveChanges();

        /// <summary>
        /// Save all changes Async.
        /// </summary>
        /// <param name="cancellationToken">Waiting for the task to complete.</param>
        /// <returns>The number of itens affecteds for async task.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
