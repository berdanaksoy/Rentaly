using FluentValidation;
using Rentaly.BusinessLayer.Constants;
using Rentaly.DtoLayer.CarModelDtos;

namespace Rentaly.BusinessLayer.ValidationRules.CarModelValidations
{
    public class CreateCarModelValidator : AbstractValidator<CreateCarModelDto>
    {
        public CreateCarModelValidator()
        {
            RuleFor(x => x.ModelName)
                .NotEmpty().WithMessage(ErrorMessages.CarModelNameRequired)
                .MinimumLength(2).WithMessage(ErrorMessages.CarModelNameLength)
                .MaximumLength(60).WithMessage(ErrorMessages.CarModelNameLength);

            RuleFor(x => x.BrandId)
                .GreaterThan(0).WithMessage(ErrorMessages.CarModelBrandRequired);
        }
    }
}