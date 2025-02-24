using MediatR;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Categories.Commands.Models
{
    public class UpdateCategoryCommand : IRequest<Response<string>>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
