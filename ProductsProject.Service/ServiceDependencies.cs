using Microsoft.Extensions.DependencyInjection;
using ProductsProject.Service.Interfaces;
using ProductsProject.Service.Services;

namespace ProductsProject.Service
{
    public static class ServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {

            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICityService, CityService>();
            return services;
        }
    }
}
