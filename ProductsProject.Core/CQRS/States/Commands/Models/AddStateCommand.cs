using MediatR;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.States.Commands.Models
{
    public class AddStateCommand : IRequest<Response<string>>
    {
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
}
