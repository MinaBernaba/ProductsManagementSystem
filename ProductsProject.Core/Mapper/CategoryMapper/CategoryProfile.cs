using AutoMapper;

namespace ProductsProject.Core.Mapper.CategoryMapper
{
    public partial class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            AddCategoryMapper();
            GetCategoryMapper();
            UpdateCategoryMapper();
        }
    }
}
