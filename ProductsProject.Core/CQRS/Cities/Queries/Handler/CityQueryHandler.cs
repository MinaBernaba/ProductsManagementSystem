using AutoMapper;
using MediatR;
using ProductsProject.Core.CQRS.Cities.Queries.Models;
using ProductsProject.Core.CQRS.Cities.Queries.Responses;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Cities.Queries.Handler
{
    public class CityQueryHandler(ICityService cityService, IMapper mapper) : ResponseHandler,
        IRequestHandler<GetCityInfoByIdQuery, Response<CityInfoResponse>>,
        IRequestHandler<GetAllCitiesMainInfoQuery, Response<List<CityInfoResponse>>>
    {
        public async Task<Response<CityInfoResponse>> Handle(GetCityInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await cityService.GetCityMainInfoAsync(request.CityId);
            if (city == null)
                return BadRequest<CityInfoResponse>($"No city with ID: {request.CityId} exists.");

            var cityInfo = mapper.Map<CityInfoResponse>(city);
            return Success(cityInfo);
        }

        public async Task<Response<List<CityInfoResponse>>> Handle(GetAllCitiesMainInfoQuery request, CancellationToken cancellationToken)
        {
            var cites = await cityService.GetAllCitiesWithInfoAsync();

            var citiesInfo = mapper.Map<List<CityInfoResponse>>(cites);

            return Success(citiesInfo);
        }
    }
}
