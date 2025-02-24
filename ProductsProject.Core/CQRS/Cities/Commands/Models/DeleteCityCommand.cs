using MediatR;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Cities.Commands.Models
{
    public class DeleteCityCommand : IRequest<Response<string>>
    {
        public int CityId { get; set; }
    }
}
