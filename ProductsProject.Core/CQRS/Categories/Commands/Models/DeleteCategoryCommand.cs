using MediatR;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Categories.Commands.Models
{
    public class DeleteCategoryCommand : IRequest<Response<string>>
    {
        public int CategoryId { get; set; }
    }
}
