using FluentValidation;
using OrderFilteringAPI.Models;

namespace OrderFilteringAPI.Validators
{
    public class FilterParamsValidator : AbstractValidator<FilterParams>
    {
        public FilterParamsValidator() 
        {
            RuleFor(filterParams => filterParams.CityDistrict)
                .NotEmpty().WithMessage("Название района не может быть пустым.");
            RuleFor(filterParams => filterParams.FirstDeliveryDateTime)
                .NotEqual(default(DateTime)).WithMessage("Некорректное время доставки");
        }
    }
}
