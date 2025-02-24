using ProductsProject.Core.CQRS.Categories.Queries.Responses;
using ProductsProject.Data.Entites;

namespace ProductsProject.Core.Mapper.CategoryMapper
{
    public partial class CategoryProfile
    {
        public void GetCategoryMapper()
        {
            CreateMap<Category, CategoryInfoResponse>();
        }
    }
}
