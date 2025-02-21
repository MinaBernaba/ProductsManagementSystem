using MediatR;
using ProductsProject.Core.CQRS.Countries.Commands.Models;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Data.Entites;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Countries.Commands.Handler
{
    public class CountryCommandHandler(ICountryService countryService, IFileService fileService) : ResponseHandler,
        IRequestHandler<AddCountryCommand, Response<string>>
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
            await countryService.AddCountryAsync(country);

            return Created<string>($"Country: {country.CountryName} added successfully with ID: {country.CountryId} !");
        }
    }
}
