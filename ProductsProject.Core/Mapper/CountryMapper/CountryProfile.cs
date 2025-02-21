using AutoMapper;

namespace ProductsProject.Core.Mapper.CountryMapper
{
    public partial class CountryProfile : Profile
    {
        public CountryProfile()
        {
            GetCountryInfoMapper();
        }
    }
}
