using MediatR;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Cities.Commands.Models
{
    public class UpdateCityCommand : IRequest<Response<string>>
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
    }
}
