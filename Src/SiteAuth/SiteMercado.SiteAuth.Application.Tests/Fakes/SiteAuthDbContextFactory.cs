using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SiteMercado.SiteAuth.Persistence;

namespace SiteMercado.SiteAuth.Application.Tests.Fakes
{
    /// <summary>
    /// SiteAuthDbContextFactory class.
    /// </summary>
    public class SiteAuthDbContextFactory : IDisposable
    {
        /// <summary>
        /// disposedValue.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Connection field.
        /// </summary>
        private DbConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteAuthDbContextFactory"/> class.
        /// </summary>
        public SiteAuthDbContextFactory()
        {
            this.connection = new SqliteConnection("DataSource=:memory:");
            this.connection.Open();

            this.Options = new DbContextOptionsBuilder<SiteAuthDbContext>().UseSqlite(this.connection).Options;
        }

        /// <summary>
        /// Gets Options.
        /// </summary>
        public DbContextOptions<SiteAuthDbContext> Options { get; private set; }

        /// <summary>
        /// CreateContextForSqlite method.
        /// </summary>
        /// <param name="context">context.</param>
        public void SeedContextForSqlite(SiteAuthDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Seed();
            context.SaveChanges();
        }

        /// <summary>
        /// Dispose method.
        /// </summary>
        public void Dispose()
        {
            if (this.connection != null)
            {
                this.connection.Dispose();
                this.connection = null;
            }
            Dispose(true);
        }

        /// <summary>
        /// Dispose virtual method.
        /// </summary>
        /// <param name="disposing">disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }
    }
}
