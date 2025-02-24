using FluentValidation;
using ProductsProject.Core.CQRS.Countries.Commands.Models;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Countries.Commands.Validators
{
    public class UpdateCountryValidator : AbstractValidator<UpdateCountryCommand>
    {
        public readonly ICountryService countryService;
        public UpdateCountryValidator(ICountryService countryService)
        {
            this.countryService = countryService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.CountryName)
                .NotEmpty().WithMessage("Name is required!")
                .NotNull().WithMessage("Name is required!")
                .MaximumLength(20).WithMessage("Name is too long!");

            RuleFor(x => x.Flag)
                .Must(flag => flag == null || flag.Length > 0)
                .WithMessage("Invalid file upload!");
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.CountryName)
               .MustAsync(async (model, countryName, cancellationToken) => !await countryService.IsCountryNameExistExceptSelfAsync(model.CountryId, countryName))
               .WithMessage(x => $"The country name {x.CountryName} exists before!");


        }
    }
}