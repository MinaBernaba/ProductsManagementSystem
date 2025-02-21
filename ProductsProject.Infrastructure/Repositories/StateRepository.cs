using ProductsProject.Data.Entites;
using ProductsProject.Infrastructure.Context;
using ProductsProject.Infrastructure.Interfaces;

namespace ProductsProject.Infrastructure.Repositories
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        public StateRepository(ApplicationDbContext context) : base(context) { }
    }
}