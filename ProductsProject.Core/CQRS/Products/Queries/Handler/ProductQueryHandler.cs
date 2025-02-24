using AutoMapper;
using MediatR;
using ProductsProject.Core.CQRS.Products.Queries.Models;
using ProductsProject.Core.CQRS.Products.Queries.Responses;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Products.Queries.Handler
{
    public class ProductQueryHandler(IProductService productService, IMapper mapper) : ResponseHandler,
        IRequestHandler<GetProductByIdQuery, Response<ProductInfoResponse>>,
        IRequestHandler<GetAllProducts, Response<List<ProductInfoResponse>>>
    {
        public async Task<Response<ProductInfoResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productService.GetProductWithCountryInfoByIdAsync(request.ProductId);
            if (product == null)
                return NotFound<ProductInfoResponse>($"No product with ID: {request.ProductId} exists.");

            var productResponse = mapper.Map<ProductInfoResponse>(product);
            return Success(productResponse);
        }

        public async Task<Response<List<ProductInfoResponse>>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var products = await productService.GetAllProductsWithCountryInfoAsync();
            var producrsResponse = mapper.Map<List<ProductInfoResponse>>(products);

            return Success(producrsResponse);
        }
    }
}
