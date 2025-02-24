using MediatR;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.States.Commands.Models
{
    public class UpdateStateCommand : IRequest<Response<string>>
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }

    }
}
