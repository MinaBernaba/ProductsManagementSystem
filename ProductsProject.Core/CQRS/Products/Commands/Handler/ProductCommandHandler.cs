using AutoMapper;
using MediatR;
using ProductsProject.Core.CQRS.Products.Commands.Models;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Data.Entites;
using ProductsProject.Data.Helper;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Products.Commands.Handler
{
    public class ProductCommandHandler(IProductService productService, IFileService fileService, IMapper mapper) : ResponseHandler,
        IRequestHandler<AddProductCommand, Response<string>>,
        IRequestHandler<UpdateProductCommand, Response<string>>,
        IRequestHandler<DeleteProductCommand, Response<string>>,
        IRequestHandler<AddCategoriesToProductCommand, Response<AddCategoriesToProductResponse>>,
        IRequestHandler<SetProductCategoriesCommand, Response<SetProductCategoriesResponse>>
    {
        public async Task<Response<string>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            string? filePath = null;

            if (request.ProductImage != null)
                filePath = await fileService.UploadFileAsync("Products", request.ProductImage);

            var product = mapper.Map<Product>(request);

            product.ProductImage = filePath;

            if (!await productService.AddProductAsync(product))
                return BadRequest<string>("Adding failed");

            return Success($"Product added successfully with ID: {product.ProductId} .");
        }

        public async Task<Response<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productService.GetProductByIdAsync(request.ProductId);
            if (product == null)
                return NotFound<string>($"No product with ID: {request.ProductId} exists!");

            if (product.ProductImage != null)
                fileService.DeleteFile(product.ProductImage);

            if (request.ProductImage != null)
                product.ProductImage = await fileService.UploadFileAsync("Products", request.ProductImage);

            else product.ProductImage = null;

            mapper.Map(request, product);

            if (!await productService.UpdateProductAsync(product))
                return BadRequest<string>();

            return Success($"Product with ID: {product.ProductId} updated successfully!");

        }

        public async Task<Response<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productService.GetProductByIdAsync(request.ProductId);
            if (product == null)
                return NotFound<string>($"No product with ID: {request.ProductId} exists!");

            if (product.ProductImage != null)
                fileService.DeleteFile(product.ProductImage);

            if (!await productService.DeleteProductAsync(product))
                return BadRequest<string>();

            return Success($"Product with ID: {product.ProductId} deleted successfully.");

        }

        public async Task<Response<AddCategoriesToProductResponse>> Handle(AddCategoriesToProductCommand request, CancellationToken cancellationToken)
        {

            if (!await productService.IsProductExistByIdAsync(request.ProductId))
                return NotFound<AddCategoriesToProductResponse>($"No product with ID: {request.ProductId} exists!");
            if (request.CategoriesIds.Count == 0)
                return BadRequest<AddCategoriesToProductResponse>($"there isn't Categories Ids provided!");
            var response = await productService.AddCategoriesToProductAsync(request.ProductId, request.CategoriesIds);

            return Success(response);

        }

        public async Task<Response<SetProductCategoriesResponse>> Handle(SetProductCategoriesCommand request, CancellationToken cancellationToken)
        {
            if (!await productService.IsProductExistByIdAsync(request.ProductId))
                return NotFound<SetProductCategoriesResponse>($"No product with ID: {request.ProductId} exists!");
            if (request.CategoriesIds.Count == 0)
                return BadRequest<SetProductCategoriesResponse>($"there isn't Categories Ids provided!");

            var response = await productService.SetProductCategoriesAsync(request.ProductId, request.CategoriesIds);

            return Success(response);
        }
    }
}
