using ProductsProject.Data.Entites;

namespace ProductsProject.Service.Interfaces
{
    public interface ICityService
    {
        Task<List<City>> GetAllCitiesAsync();
        Task<List<City>> GetAllCitiesWithInfoAsync();
        Task<City> GetCityByIdAsync(int id);

        Task<bool> IsCityExistByIdAsync(int CityId);
        Task<City?> GetCityMainInfoAsync(int cityId);
        Task<bool> IsCityNameExistAsync(string CityName);
        Task<bool> IsCityNameExistExceptSelfAsync(int cityId, string CityName);

        Task<bool> AddCityAsync(City City);

        Task<bool> UpdateCityAsync(City City);
        Task<bool> DeleteCityAsync(City City);
    }
}
