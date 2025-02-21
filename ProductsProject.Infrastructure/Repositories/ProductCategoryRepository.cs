using ProductsProject.Data.Entites;
using ProductsProject.Infrastructure.Context;
using ProductsProject.Infrastructure.Interfaces;

namespace ProductsProject.Infrastructure.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ApplicationDbContext context) : base(context) { }

    }
}
