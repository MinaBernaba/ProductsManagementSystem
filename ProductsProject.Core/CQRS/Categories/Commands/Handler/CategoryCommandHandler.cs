using AutoMapper;
using MediatR;
using ProductsProject.Core.CQRS.Categories.Commands.Models;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Data.Entites;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Categories.Commands.Handler
{
    public class CategoryCommandHandler(ICategoryService categoryService, IMapper mapper) : ResponseHandler,
        IRequestHandler<AddCategoryCommand, Response<string>>,
        IRequestHandler<UpdateCategoryCommand, Response<string>>,
        IRequestHandler<DeleteCategoryCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);

            if (!await categoryService.AddCategoryAsync(category))
                return BadRequest<string>();
            return Success($"Category: {category.CategoryName} added successfully with ID: {category.CategoryId} .");

        }

        public async Task<Response<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryService.GetCategoryByIdAsync(request.CategoryId);
            if (category == null)
                return NotFound<string>($"No category with ID: {request.CategoryId} exists!");

            mapper.Map(request, category);

            if (!await categoryService.UpdateCategoryAsync(category))
                return BadRequest<string>();

            return Success($"Category with ID: {category.CategoryId} updated successfully!");
        }

        public async Task<Response<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryService.GetCategoryByIdAsync(request.CategoryId);
            if (category == null)
                return NotFound<string>($"No category with ID: {request.CategoryId} exists!");

            if (!await categoryService.DeleteCategoryAsync(category))
                return BadRequest<string>();

            return Success($"Category with ID: {request.CategoryId} deleted successfully.");
        }
    }
}
