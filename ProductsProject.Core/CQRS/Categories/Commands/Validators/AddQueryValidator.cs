using FluentValidation;
using ProductsProject.Core.CQRS.Categories.Commands.Models;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Categories.Commands.Validators
{
    public class AddQueryValidator : AbstractValidator<AddCategoryCommand>
    {
        private readonly ICategoryService categoryService;

        public AddQueryValidator(ICategoryService categoryService)
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
            RuleFor(x => x.CategoryName)
               .MustAsync(async (categoryName, cancellationToken) => !await categoryService.IsCategoryExistByNameAsync(categoryName))
               .WithMessage(x => $"The Category name {x.CategoryName} exists before!");


        }
    }
}
