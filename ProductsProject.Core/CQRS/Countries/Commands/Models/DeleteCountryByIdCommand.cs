using MediatR;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Countries.Commands.Models
{
    public class DeleteCountryByIdCommand : IRequest<Response<string>>
    {
        public int CountryId { get; set; }
    }
}
