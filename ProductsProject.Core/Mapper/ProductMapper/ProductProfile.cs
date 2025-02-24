using AutoMapper;

namespace ProductsProject.Core.Mapper.ProductMapper
{
    public partial class ProductProfile : Profile
    {
        public ProductProfile()
        {
            GetProductMainInfoMapper();
            AddProductMapper();
            UpdateProductMapper();
        }
    }
}
