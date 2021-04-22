using AutoMapper;
using SiteMercado.SiteAuth.Application.Products.Models;

namespace SiteMercado.SiteAuth.Application.Products.Mappings
{
    /// <summary>
    /// Products Mappings class.
    /// </summary>
    public class ProductsMappings : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsMappings"/> class.
        /// </summary>
        public ProductsMappings()
        {
            CreateMap<Domain.Entities.Product, ProductModel>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
