using System;
using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SiteMercado.SiteAuth.Application.Products.Mappings;
using SiteMercado.SiteAuth.Persistence;
using Xunit;

namespace SiteMercado.SiteAuth.Application.Tests
{
    /// <summary>
    /// TestBase.
    /// </summary>
    public class TestBase
    {
        private static MapperConfiguration mockMapper;

        private readonly SqliteConnection inMemorySqlite;

        /// <summary>
        /// Gets automapper instance.
        /// </summary>
        public IMapper Mapper => SubstituteAutoMapper();

        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase"/> class.
        /// </summary>
        public TestBase()
        {
            inMemorySqlite = new SqliteConnection("Data Source=:memory:");

            // InitializeAutoMapper();
        }

        /// <summary>
        /// Creates a dbContext for testing.
        /// </summary>
        /// <param name="useSqlLite">Use SqlLite. If false, uses memory provider.</param>
        /// <returns>dbContext.</returns>
        public ISiteAuthDbContext GetEntityDbContext(bool useSqlLite = false)
        {
            var builder = new DbContextOptionsBuilder<SiteAuthDbContext>();

            if (useSqlLite)
            {
                builder.UseSqlite(inMemorySqlite, x => { });
            }
            else
            {
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }

            builder.EnableSensitiveDataLogging(true);

            var dbContext = new SiteAuthDbContext(builder.Options);

            if (useSqlLite)
            {
                // SQLite needs to open connection to the DB.
                // Not required for in-memory-database.
                dbContext.Database.OpenConnection();
            }

            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        /// <summary>
        /// SubstituteAutoMapper static method.
        /// </summary>
        /// <returns>IMapper.</returns>
        private static IMapper SubstituteAutoMapper()
        {
            mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductsMappings());
            });

            mockMapper.AssertConfigurationIsValid();
            var mapper = mockMapper.CreateMapper();
            return mapper;
        }

        /// <summary>
        /// MemberDateTime.
        /// </summary>
        protected static readonly TheoryData<DateTime> MemberDateTime = new TheoryData<DateTime>
        {
            DateTime.Now,
            default(DateTime),
            DateTime.MaxValue
        };
    }
}
