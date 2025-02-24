using FluentValidation;
using ProductsProject.Core.CQRS.States.Commands.Models;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.States.Commands.Validators
{
    public class AddStateValidator : AbstractValidator<AddStateCommand>
    {
        public readonly ICountryService countryService;

        public AddStateValidator(ICountryService countryService)
        {
            this.countryService = countryService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.StateName)
                .NotEmpty().WithMessage("Name is required!")
                .NotNull().WithMessage("Name is required!")
                .MaximumLength(20).WithMessage("Name is too long!");

        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.CountryId)
               .MustAsync(async (countryId, cancellationToken) => await countryService.IsCountryExistByIdAsync(countryId))
               .WithMessage(x => $"The country ID: {x.CountryId} doesn't exist!");
        }
    }
}