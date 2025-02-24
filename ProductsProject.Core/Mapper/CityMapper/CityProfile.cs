using AutoMapper;

namespace ProductsProject.Core.Mapper.CityMapper
{
    public partial class CityProfile : Profile
    {
        public CityProfile()
        {
            GetCityMainInfoMapper();
            AddCityMapper();
            UpdateCityMapper();
        }
    }
}
