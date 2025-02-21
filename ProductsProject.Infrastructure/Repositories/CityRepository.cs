using ProductsProject.Data.Entites;
using ProductsProject.Infrastructure.Context;
using ProductsProject.Infrastructure.Interfaces;

namespace ProductsProject.Infrastructure.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context) { }
    }
}
