using AutoMapper;
using MediatR;
using ProductsProject.Core.CQRS.Countries.Queries.Models;
using ProductsProject.Core.CQRS.Countries.Queries.Responses;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Countries.Queries.Handler
{
    public class CountriesQueryHandler(ICountryService countryService, IMapper mapper) : ResponseHandler,
        IRequestHandler<GetCountryByIdQuery, Response<CountryInfoResponse>>,
        IRequestHandler<GetAllCountriesQuery, Response<List<CountryInfoResponse>>>
    {
        public async Task<Response<CountryInfoResponse>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await countryService.GetCountryAsync(request.CountryId);
            if (country == null)
                return NotFound<CountryInfoResponse>($"No country with ID:{request.CountryId} exists!");

            var countryMapper = mapper.Map<CountryInfoResponse>(country);
            return Success(countryMapper);
        }

        public async Task<Response<List<CountryInfoResponse>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await countryService.GetAllCountriesAsync();

            var countriesMapper = mapper.Map<List<CountryInfoResponse>>(countries);

            return Success(countriesMapper);
        }
    }
}
