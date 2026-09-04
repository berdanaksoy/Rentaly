using FluentValidation;
using Rentaly.BusinessLayer.Constants;
using Rentaly.DtoLayer.CarModelDtos;

namespace Rentaly.BusinessLayer.ValidationRules.CarModelValidations
{
    public class UpdateCarModelValidator : AbstractValidator<UpdateCarModelDto>
    {
        public UpdateCarModelValidator()
        {
            RuleFor(x => x.CarModelId)
                .GreaterThan(0).WithMessage("Geçerli bir model seçilmelidir.");

            RuleFor(x => x.ModelName)
                .NotEmpty().WithMessage(ErrorMessages.CarModelNameRequired)
                .MinimumLength(2).WithMessage(ErrorMessages.CarModelNameLength)
                .MaximumLength(60).WithMessage(ErrorMessages.CarModelNameLength);

            RuleFor(x => x.BrandId)
                .GreaterThan(0).WithMessage(ErrorMessages.CarModelBrandRequired);
        }
    }
}