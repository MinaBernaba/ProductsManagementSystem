using AutoMapper;

namespace ProductsProject.Core.Mapper.StateMapper
{
    public partial class StateProfile : Profile
    {
        public StateProfile()
        {
            GetStateWithCountryMapper();
            AddStateMapper();
            UpdateStateMapper();
        }
    }
}
