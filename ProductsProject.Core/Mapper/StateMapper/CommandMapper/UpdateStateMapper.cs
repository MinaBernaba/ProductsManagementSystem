using ProductsProject.Core.CQRS.States.Commands.Models;
using ProductsProject.Data.Entites;

namespace ProductsProject.Core.Mapper.StateMapper
{
    public partial class StateProfile
    {
        public void UpdateStateMapper()
        {
            CreateMap<UpdateStateCommand, State>();
        }
    }
}
