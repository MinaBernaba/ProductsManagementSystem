using AutoMapper;
using MediatR;
using ProductsProject.Core.CQRS.Categories.Queries.Models;
using ProductsProject.Core.CQRS.Categories.Queries.Responses;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Categories.Queries.Handler
{
    public class CategoryQueryHandler(ICategoryService categoryService, IMapper mapper) : ResponseHandler,
        IRequestHandler<GetCategoryByIdQuery, Response<CategoryInfoResponse>>,
        IRequestHandler<GetAllCategories, Response<List<CategoryInfoResponse>>>
    {
        public async Task<Response<CategoryInfoResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await categoryService.GetCategoryByIdAsync(request.CategoryId);
            if (category == null)
                return NotFound<CategoryInfoResponse>($"No category with ID: {request.CategoryId} exists.");

            var categoryMapper = mapper.Map<CategoryInfoResponse>(category);
            return Success(categoryMapper);
        }

        public async Task<Response<List<CategoryInfoResponse>>> Handle(GetAllCategories request, CancellationToken cancellationToken)
        {
            var categories = await categoryService.GetAllCategoriesAsync();
            var categoriesMapper = mapper.Map<List<CategoryInfoResponse>>(categories);
            return Success(categoriesMapper);
        }
    }
}
