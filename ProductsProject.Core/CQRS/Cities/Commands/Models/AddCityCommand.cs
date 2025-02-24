using MediatR;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Cities.Commands.Models
{
    public class AddCityCommand : IRequest<Response<string>>
    {
        public string CityName { get; set; }
        public int StateId { get; set; }
    }
}
