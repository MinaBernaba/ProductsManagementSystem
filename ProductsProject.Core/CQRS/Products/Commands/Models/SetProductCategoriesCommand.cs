using MediatR;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Data.Helper;

namespace ProductsProject.Core.CQRS.Products.Commands.Models
{
    public class SetProductCategoriesCommand : IRequest<Response<SetProductCategoriesResponse>>
    {
        public int ProductId { get; set; }
        public HashSet<int> CategoriesIds { get; set; }
    }
}
