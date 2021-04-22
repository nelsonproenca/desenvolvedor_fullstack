using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiteMercado.SiteAuth.Dic;
using SiteMercado.SiteAuth.WebApi.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace SiteMercado.SiteAuth.WebApi
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ErrorHandlerAttribute));
            })
           .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddMvcCore(options =>
            {
                options.Filters.Add(typeof(ErrorHandlerAttribute));
            });

            DependencyInjectionContainer.InitializeApplicationServices(services, Configuration);

            // Swagger
            services.AddSwaggerGen(options =>
            {
                // version
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Multi Channel API v1",
                    Description = "Multi Channel Web API - Module SiteAuths Microservice.",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "White Star ", Email = "nelson.proenca@whitestar.pt", Url = "www.whitestar.pt" }
                });

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "SiteMercado.SiteAuth.WebApi.xml"));
                options.DescribeAllEnumsAsStrings();
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        /// </summary>
        /// <param name="app">app.</param>
        /// <param name="env">env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Multi Channel API v1");
            });
        }
    }
}
