using ProductsProject.Data.Entites;
using ProductsProject.Infrastructure.Context;
using ProductsProject.Infrastructure.Interfaces;

namespace ProductsProject.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

    }
}
