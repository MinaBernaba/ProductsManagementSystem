using MediatR;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Products.Commands.Models
{
    public class DeleteProductCommand : IRequest<Response<string>>
    {
        public int ProductId { get; set; }
    }
}
