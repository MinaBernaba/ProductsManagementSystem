using ProductsProject.Core.CQRS.Cities.Commands.Models;
using ProductsProject.Data.Entites;

namespace ProductsProject.Core.Mapper.CityMapper
{
    public partial class CityProfile
    {
        public void UpdateCityMapper()
        {
            CreateMap<UpdateCityCommand, City>();
        }
    }
}
