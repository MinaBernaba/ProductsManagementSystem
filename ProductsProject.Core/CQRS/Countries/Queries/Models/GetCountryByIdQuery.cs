using MediatR;
using ProductsProject.Core.CQRS.Countries.Queries.Responses;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Countries.Queries.Models
{
    public class GetCountryByIdQuery : IRequest<Response<CountryInfoResponse>>
    {
        public int CountryId { get; set; }
    }
}
