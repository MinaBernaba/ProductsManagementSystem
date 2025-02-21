using Microsoft.EntityFrameworkCore;
using ProductsProject.Data.Entites;

namespace ProductsProject.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        #region Db sets 

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        #endregion
    }
}
