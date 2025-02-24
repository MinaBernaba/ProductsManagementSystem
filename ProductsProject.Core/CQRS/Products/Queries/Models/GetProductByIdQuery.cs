using MediatR;
using ProductsProject.Core.CQRS.Products.Queries.Responses;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Products.Queries.Models
{
    public class GetProductByIdQuery : IRequest<Response<ProductInfoResponse>>
    {
        public int ProductId { get; set; }
    }
}
