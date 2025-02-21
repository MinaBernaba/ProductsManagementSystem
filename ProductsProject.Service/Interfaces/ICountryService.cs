using ProductsProject.Data.Entites;

namespace ProductsProject.Service.Interfaces
{
    public interface ICountryService
    {
        Task AddCountryAsync(Country country);
        Task<Country> GetCountryAsync(int countryId);
    }
}
