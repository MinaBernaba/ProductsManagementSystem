using ProductsProject.Core.CQRS.Products.Commands.Models;
using ProductsProject.Data.Entites;

namespace ProductsProject.Core.Mapper.ProductMapper
{
    public partial class ProductProfile
    {
        public void AddProductMapper()
        {
            CreateMap<AddProductCommand, Product>()
                .ForMember(dest => dest.ProductImage, source => source.Ignore());
        }
    }
}
