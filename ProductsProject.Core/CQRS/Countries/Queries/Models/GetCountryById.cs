using MediatR;
using ProductsProject.Core.CQRS.Countries.Queries.Responses;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Countries.Queries.Models
{
    public class GetCountryById : IRequest<Response<CountryInfo>>
    {
        public int CountryId { get; set; }
    }
}
