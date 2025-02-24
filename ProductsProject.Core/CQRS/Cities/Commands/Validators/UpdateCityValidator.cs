using FluentValidation;
using ProductsProject.Core.CQRS.Cities.Commands.Models;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.Cities.Commands.Validators
{
    public class UpdateCityValidator : AbstractValidator<UpdateCityCommand>
    {
        private readonly IStateService stateService;
        private readonly ICityService cityService;

        public UpdateCityValidator(IStateService stateService, ICityService cityService)
        {
            this.stateService = stateService;
            this.cityService = cityService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.CityName)
                .NotEmpty().WithMessage("Name is required!")
                .NotNull().WithMessage("Name is required!")
                .MaximumLength(20).WithMessage("Name is too long!");
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.StateId)
               .MustAsync(async (stateId, cancellationToken) => await stateService.IsStateExistByIdAsync(stateId))
               .WithMessage(x => $"The state ID: {x.StateId} doesn't exist!");

            RuleFor(x => x.CityName)
               .MustAsync(async (model, cityName, cancellationToken) => !await cityService.IsCityNameExistExceptSelfAsync(model.CityId, cityName))
               .WithMessage(x => $"City {x.CityName} exists before!");


        }
    }
}
