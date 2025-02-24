using MediatR;
using Microsoft.AspNetCore.Http;
using ProductsProject.Core.ResponseBase;

namespace ProductsProject.Core.CQRS.Products.Commands.Models
{
    public class UpdateProductCommand : IRequest<Response<string>>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public IFormFile? ProductImage { get; set; }
        public int CountryId { get; set; }

    }
}
