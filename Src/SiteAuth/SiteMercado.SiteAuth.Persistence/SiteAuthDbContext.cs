using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SiteMercado.SiteAuth.Domain.Entities;

namespace SiteMercado.SiteAuth.Persistence
{
    /// <summary>
    /// SiteAuth DbContext class.
    /// </summary>
    public class SiteAuthDbContext : DbContext, ISiteAuthDbContext
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteAuthDbContext"/> class.
        /// </summary>
        /// <param name="options">DbContext options.</param>
        /// <param name="configuration">configuration.</param>
        public SiteAuthDbContext(DbContextOptions<SiteAuthDbContext> options, IConfiguration configuration)
            : base(options)
        {
            connectionString = ConfigurationExtensions.GetConnectionString(configuration, "SiteAuthConnectionString");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteAuthDbContext"/> class.
        /// </summary>
        /// <param name="options">DbContext options.</param>
        public SiteAuthDbContext(DbContextOptions<SiteAuthDbContext> options)
            : base(options)
        {
        }

        /// <inheritdoc/>
        public DbSet<Product> Products { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (this.connectionString != null)
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }
                else
                {
                    optionsBuilder.UseSqlServer(@"Server=WSPTVWDBMSSRV03\\APPSDEV;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
                }
            }

            base.OnConfiguring(optionsBuilder);
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Product>().HasKey(key => key.Id);

            modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnType("varchar (2048)");
            modelBuilder.Entity<Product>().Property(p => p.ImageUrl).HasColumnType("varchar (MAX)");
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal (12, 4)");
        }
    }
}
