using MediatR;
using Microsoft.AspNetCore.Http;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Countries.Commands.Models
{
    public class AddCountryCommand : IRequest<Response<string>>
    {
        public string CountryName { get; set; }
        public IFormFile? Flag { get; set; }
    }
}
