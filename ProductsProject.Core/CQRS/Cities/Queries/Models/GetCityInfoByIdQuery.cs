using MediatR;
using ProductsProject.Core.CQRS.Cities.Queries.Responses;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Cities.Queries.Models
{
    public class GetCityInfoByIdQuery : IRequest<Response<CityInfoResponse>>
    {
        public int CityId { get; set; }
    }
}
