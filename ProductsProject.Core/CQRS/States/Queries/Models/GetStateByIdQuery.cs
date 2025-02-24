using MediatR;
using ProductsProject.Core.CQRS.States.Queries.Responses;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.States.Queries.Models
{
    public class GetStateByIdQuery : IRequest<Response<GetStateWithCountryResponse>>
    {
        public int StateId { get; set; }
    }
}
