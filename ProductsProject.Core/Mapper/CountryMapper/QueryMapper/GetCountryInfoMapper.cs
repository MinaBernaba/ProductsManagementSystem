using ProductsProject.Core.CQRS.Countries.Queries.Responses;
using ProductsProject.Data.Entites;

namespace ProductsProject.Core.Mapper.CountryMapper
{
    public partial class CountryProfile
    {
        public void GetCountryInfoMapper()
        {
            CreateMap<Country, CountryInfoResponse>();
        }
    }
}
