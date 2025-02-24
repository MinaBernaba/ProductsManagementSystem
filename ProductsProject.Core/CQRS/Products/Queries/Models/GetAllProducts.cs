using MediatR;
using ProductsProject.Core.CQRS.Products.Queries.Responses;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Products.Queries.Models
{
    public class GetAllProducts : IRequest<Response<List<ProductInfoResponse>>>
    {
    }
}
