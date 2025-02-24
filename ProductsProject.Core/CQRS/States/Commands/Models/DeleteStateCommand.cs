using MediatR;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.States.Commands.Models
{
    public class DeleteStateCommand : IRequest<Response<string>>
    {
        public int StateId { get; set; }
    }
}
