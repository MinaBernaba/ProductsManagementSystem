using MediatR;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.City.Commands.Models
{
    public class AddCityCommand : IRequest<Response<string>>
    {

    }
}
