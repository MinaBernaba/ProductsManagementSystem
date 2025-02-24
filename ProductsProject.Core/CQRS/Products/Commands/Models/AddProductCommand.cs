using MediatR;
using Microsoft.AspNetCore.Http;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Products.Commands.Models
{
    public class AddProductCommand : IRequest<Response<string>>
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public IFormFile? ProductImage { get; set; }
        public int CountryId { get; set; }
    }
}
