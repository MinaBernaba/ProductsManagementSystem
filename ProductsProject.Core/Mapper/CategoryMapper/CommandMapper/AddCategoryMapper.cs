using ProductsProject.Core.CQRS.Categories.Commands.Models;
using ProductsProject.Data.Entites;

namespace ProductsProject.Core.Mapper.CategoryMapper
{
    public partial class CategoryProfile
    {
        public void AddCategoryMapper()
        {
            CreateMap<AddCategoryCommand, Category>();
        }
    }
}
