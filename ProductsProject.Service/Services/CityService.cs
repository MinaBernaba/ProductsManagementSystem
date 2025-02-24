using Microsoft.EntityFrameworkCore;
using ProductsProject.Data.Entites;
using ProductsProject.Infrastructure.Interfaces;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Service.Services
{
    public class CityService(IUnitOfWork unitOfWork) : ICityService
    {
        public async Task<List<City>> GetAllCitiesAsync()
        => await unitOfWork.Cities.GetAllNoTracking().ToListAsync();

        public async Task<List<City>> GetAllCitiesWithInfoAsync()
        => await unitOfWork.Cities.GetAllNoTracking().Include(x => x.State).ThenInclude(x => x.Country).ToListAsync();

        public async Task<City> GetCityByIdAsync(int id)
        => await unitOfWork.Cities.GetByIdAsync(id);

        public async Task<City?> GetCityMainInfoAsync(int cityId)
        => await unitOfWork.Cities.GetAllNoTracking().Where(x => x.CityId == cityId).Include(x => x.State).ThenInclude(x => x.Country).FirstOrDefaultAsync();

        public async Task<bool> IsCityExistByIdAsync(int CityId)
       => await unitOfWork.Cities.IsExist(x => x.CityId.Equals(CityId));

        public async Task<bool> IsCityNameExistAsync(string CityName)
        => await unitOfWork.Cities.IsExist(x => x.CityName.ToLower() == CityName.ToLower());
        public async Task<bool> IsCityNameExistExceptSelfAsync(int cityId, string CityName)
            => await unitOfWork.Cities.IsExist(x => x.CityName.ToLower() == CityName.ToLower() && x.CityId != cityId);
        public async Task<bool> AddCityAsync(City City)
        {
            await unitOfWork.Cities.AddAsync(City);
            return await unitOfWork.SaveChangesAsync() > 0;

        }
        public async Task<bool> UpdateCityAsync(City City)
        {
            unitOfWork.Cities.Update(City);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteCityAsync(City City)
        {
            unitOfWork.Cities.Delete(City);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
