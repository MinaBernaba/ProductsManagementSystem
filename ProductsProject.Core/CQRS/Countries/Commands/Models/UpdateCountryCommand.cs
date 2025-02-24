using MediatR;
using Microsoft.AspNetCore.Http;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Countries.Commands.Models
{
    public class UpdateCountryCommand : IRequest<Response<string>>
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public IFormFile? Flag { get; set; }
    }
}
