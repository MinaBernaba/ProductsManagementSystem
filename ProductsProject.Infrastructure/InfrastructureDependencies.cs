using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsProject.Infrastructure.Context;
using ProductsProject.Infrastructure.Interfaces;
using ProductsProject.Infrastructure.Repositories;

namespace ProductsProject.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            #region Register DbContext with SQL Server using connection string from appsettings.json 

            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #endregion

            #region Register repositories and unit of work
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            return services;
        }
    }
}
