using FluentValidation;
using ProductsProject.Core.CQRS.Categories.Commands.Models;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Categories.Commands.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryService categoryService;

        public UpdateCategoryValidator(ICategoryService categoryService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            this.categoryService = categoryService;
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Name is required!")
                .NotNull().WithMessage("Name is required!")
                .MaximumLength(20).WithMessage("Name is too long!");
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.CategoryId)
               .MustAsync(async (categoryId, cancellationToken) => await categoryService.IsCategoryExistByIdAsync(categoryId))
               .WithMessage(x => $"The Category ID: {x.CategoryId} doesn't exist!");

        }
    }
}
