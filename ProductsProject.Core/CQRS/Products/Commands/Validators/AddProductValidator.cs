using FluentValidation;
using ProductsProject.Core.CQRS.Products.Commands.Models;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Products.Commands.Validators
{
    public class AddProductValidator : AbstractValidator<AddProductCommand>
    {
        private readonly ICountryService countryService;

        public AddProductValidator(ICountryService countryService)
        {
            this.countryService = countryService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required!")
                .NotNull().WithMessage("Price is required!")
                .GreaterThan(0).WithMessage("Invalid price")
                .LessThan(10000000).WithMessage("Invalid price");

            RuleFor(x => x.ProductName)
               .NotEmpty().WithMessage("Product Name is required!")
               .NotNull().WithMessage("Product Name is required!")
               .MaximumLength(20).WithMessage("Product name is too long");

            RuleFor(x => x.ProductImage)
                .Must(flag => flag == null || flag.Length > 0)
                .WithMessage("Invalid file upload!");
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.CountryId)
               .MustAsync(async (countryId, cancellationToken) => await countryService.IsCountryExistByIdAsync(countryId))
               .WithMessage(x => $"The country ID: {x.CountryId} doesn't exist!");
        }
    }
}