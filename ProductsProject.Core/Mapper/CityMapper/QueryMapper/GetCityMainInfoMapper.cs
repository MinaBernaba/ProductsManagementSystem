using ProductsProject.Core.CQRS.Cities.Queries.Responses;
using ProductsProject.Data.Entites;

namespace ProductsProject.Core.Mapper.CityMapper
{
    public partial class CityProfile
    {
        public void GetCityMainInfoMapper()
        {
            CreateMap<City, CityInfoResponse>()
                .ForMember(dest => dest.StateName, source => source.MapFrom(source => source.State.StateName))
                .ForMember(dest => dest.CountryName, source => source.MapFrom(source => source.State.Country.CountryName));
        }
    }
}
