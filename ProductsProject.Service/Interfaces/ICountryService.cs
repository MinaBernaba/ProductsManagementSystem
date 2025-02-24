using ProductsProject.Data.Entites;

namespace ProductsProject.Service.Interfaces
{
    public interface ICountryService
    {
        Task<bool> IsCountryNameExistAsync(string countryName);
        Task<bool> IsCountryNameExistExceptSelfAsync(int countryId, string countryName);
        Task<bool> IsCountryExistByIdAsync(int countryId);
        Task<Country> GetCountryAsync(int countryId);
        Task<List<Country>> GetAllCountriesAsync();
        Task<bool> AddCountryAsync(Country country);
        Task<bool> UpdateCountryAsync(Country country);
        Task<bool> DeleteCountryAsync(int countryId);
    }
}
