using ProductsProject.Data.Entites;
using ProductsProject.Infrastructure.Context;
using ProductsProject.Infrastructure.Interfaces;

namespace ProductsProject.Infrastructure.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context) : base(context) { }


    }
}
