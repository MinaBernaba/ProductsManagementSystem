using ProductsProject.Core.CQRS.States.Queries.Responses;
using ProductsProject.Data.Entites;

namespace ProductsProject.Core.Mapper.StateMapper
{
    public partial class StateProfile
    {
        public void GetStateWithCountryMapper()
        {
            CreateMap<State, GetStateWithCountryResponse>()
              .ForMember(dest => dest.CountryName, source => source.MapFrom(source => source.Country.CountryName));
        }
    }
}
