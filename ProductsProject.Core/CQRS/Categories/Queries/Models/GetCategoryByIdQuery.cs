using MediatR;
using ProductsProject.Core.CQRS.Categories.Queries.Responses;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Categories.Queries.Models
{
    public class GetCategoryByIdQuery : IRequest<Response<CategoryInfoResponse>>
    {
        public int CategoryId { get; set; }
    }
}
