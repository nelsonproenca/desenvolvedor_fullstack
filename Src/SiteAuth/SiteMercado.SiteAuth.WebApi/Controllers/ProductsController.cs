using Microsoft.AspNetCore.Mvc;
using SiteMercado.SiteAuth.WebApi.Filters;

namespace SiteMercado.SiteAuth.WebApi.Controllers
{
    /// <summary>
    /// SiteAuths Controller class.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ErrorHandler]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        public ProductsController()
        {
        }
    }
}
