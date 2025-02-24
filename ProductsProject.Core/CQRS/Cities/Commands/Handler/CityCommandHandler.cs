using AutoMapper;
using MediatR;
using ProductsProject.Core.CQRS.Cities.Commands.Models;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Data.Entites;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Cities.Commands.Handler
{
    public class CityCommandHandler(ICityService cityService, IMapper mapper) : ResponseHandler,
        IRequestHandler<AddCityCommand, Response<string>>,
        IRequestHandler<UpdateCityCommand, Response<string>>,
        IRequestHandler<DeleteCityCommand, Response<string>>

    {
        public async Task<Response<string>> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            var city = mapper.Map<City>(request);

            if (!await cityService.AddCityAsync(city))
                return BadRequest<string>();

            return Success($"City with ID: {city.CityId} added successfully.");
        }

        public async Task<Response<string>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await cityService.GetCityByIdAsync(request.CityId);
            if (city == null)
                return BadRequest<string>($"No city with ID: {request.CityId} exists.");

            mapper.Map(request, city);
            if (!await cityService.UpdateCityAsync(city))
                return BadRequest<string>();

            return Success($"City with ID: {city.CityId} updated successfully.");

        }

        public async Task<Response<string>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await cityService.GetCityByIdAsync(request.CityId);
            if (city == null)
                return BadRequest<string>($"No city with ID: {request.CityId} exists.");

            if (!await cityService.DeleteCityAsync(city))
                return BadRequest<string>();

            return Success($"City with ID: {city.CityId} deleted successfully.");
        }
    }
}
