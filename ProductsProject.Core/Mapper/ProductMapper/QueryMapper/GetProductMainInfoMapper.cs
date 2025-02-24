using ProductsProject.Core.CQRS.Products.Queries.Responses;
using ProductsProject.Data.Entites;

namespace ProductsProject.Core.Mapper.ProductMapper
{
    public partial class ProductProfile
    {
        public void GetProductMainInfoMapper()
        {
            CreateMap<Product, ProductInfoResponse>()
                .ForMember(dest => dest.CountryName, source => source.MapFrom(source => source.Country.CountryName));
        }
    }
}
