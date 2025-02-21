using AutoMapper;
using MediatR;
using ProductsProject.Core.CQRS.Countries.Queries.Models;
using ProductsProject.Core.CQRS.Countries.Queries.Responses;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Countries.Queries.Handler
{
    public class CountriesQueryHandler(ICountryService countryService, IMapper mapper) : ResponseHandler,
        IRequestHandler<GetCountryById, Response<CountryInfo>>
    {
        public async Task<Response<CountryInfo>> Handle(GetCountryById request, CancellationToken cancellationToken)
        {
            var country = await countryService.GetCountryAsync(request.CountryId);
            if (country == null)
                return BadRequest<CountryInfo>($"No country with ID:{request.CountryId} exists!");

            var countryMapper = mapper.Map<CountryInfo>(country);
            return Success(countryMapper);
        }
    }
}
