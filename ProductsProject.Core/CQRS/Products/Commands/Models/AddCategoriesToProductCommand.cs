using MediatR;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Data.Helper;

namespace ProductsProject.Core.CQRS.Products.Commands.Models
{
    public class AddCategoriesToProductCommand : IRequest<Response<AddCategoriesToProductResponse>>
    {
        public int ProductId { get; set; }
        public HashSet<int> CategoriesIds { get; set; }
    }
}
