using Microsoft.EntityFrameworkCore;
using ProductsProject.Data.Entites;
using ProductsProject.Infrastructure.Interfaces;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Service.Services
{
    public class CountryService(IFileService fileService, IUnitOfWork unitOfWork) : ICountryService
    {
        public async Task<bool> IsCountryNameExistAsync(string countryName) => await unitOfWork.Countries.IsExist(x => x.CountryName.Equals(countryName));
        public async Task<bool> IsCountryNameExistExceptSelfAsync(int countryId, string countryName) =>
           await unitOfWork.Countries.IsExist(x => x.CountryName.Equals(countryName) && !x.CountryId.Equals(countryId));
        public async Task<bool> IsCountryExistByIdAsync(int countryId) =>
            await unitOfWork.Countries.IsExist(x => x.CountryId.Equals(countryId));
        public async Task<Country> GetCountryAsync(int countryId) => await unitOfWork.Countries.GetByIdAsync(countryId);
        public async Task<List<Country>> GetAllCountriesAsync() => await unitOfWork.Countries.GetAllNoTracking().ToListAsync();
        public async Task<bool> AddCountryAsync(Country country)
        {
            await unitOfWork.Countries.AddAsync(country);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateCountryAsync(Country country)
        {
            unitOfWork.Countries.Update(country);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteCountryAsync(int countryId)
        {
            var country = await unitOfWork.Countries.GetByIdAsync(countryId);

            if (country == null)
                return false;

            if (country.Flag != null)
                fileService.DeleteFile(country.Flag);

            unitOfWork.Countries.Delete(country);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
    }
}