using MediatR;
using ProductsProject.Core.CQRS.Countries.Commands.Models;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Data.Entites;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Countries.Commands.Handler
{
    public class CountryCommandHandler(ICountryService countryService, IFileService fileService) : ResponseHandler,
        IRequestHandler<AddCountryCommand, Response<string>>,
        IRequestHandler<DeleteCountryByIdCommand, Response<string>>,
        IRequestHandler<UpdateCountryCommand, Response<string>>

    {
        public async Task<Response<string>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            string? filePath = null;

            if (request.Flag != null)
                filePath = await fileService.UploadFileAsync("Flags", request.Flag);

            Country country = new Country()
            {
                CountryName = request.CountryName,
                Flag = filePath
            };
            if (!await countryService.AddCountryAsync(country))
                return BadRequest<string>();

            return Created<string>($"Country: {country.CountryName} added successfully with ID: {country.CountryId} !");
        }

        public async Task<Response<string>> Handle(DeleteCountryByIdCommand request, CancellationToken cancellationToken)
        {
            if (!await countryService.DeleteCountryAsync(request.CountryId))
                return NotFound<string>($"No country with ID: {request.CountryId} exists!");

            return Success($"Country with ID: {request.CountryId} deleted successfully!");

        }

        public async Task<Response<string>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await countryService.GetCountryAsync(request.CountryId);
            if (country == null)
                return NotFound<string>($"No country with ID: {request.CountryId} exists!");

            country.CountryName = request.CountryName;

            if (!string.IsNullOrWhiteSpace(country.Flag))
                fileService.DeleteFile(country.Flag);

            if (request.Flag != null)
                country.Flag = await fileService.UploadFileAsync("Flags", request.Flag);

            else
                country.Flag = null;

            await countryService.UpdateCountryAsync(country);

            return Success($"Country with ID: {country.CountryId} updated successfully.");
        }
    }
}
