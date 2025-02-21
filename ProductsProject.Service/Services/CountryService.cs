using Microsoft.AspNetCore.Hosting;
using ProductsProject.Data.Entites;
using ProductsProject.Infrastructure.Interfaces;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Service.Services
{
    public class CountryService(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : ICountryService
    {
        public async Task AddCountryAsync(Country country)
        {
            await unitOfWork.Countries.AddAsync(country);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<Country> GetCountryAsync(int countryId) => await unitOfWork.Countries.GetByIdAsync(countryId);

    }
}