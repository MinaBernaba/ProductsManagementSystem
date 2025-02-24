using MediatR;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Categories.Commands.Models
{
    public class AddCategoryCommand : IRequest<Response<string>>
    {
        public string CategoryName { get; set; }
    }
}
