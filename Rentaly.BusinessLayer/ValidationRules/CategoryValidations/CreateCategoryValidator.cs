using FluentValidation;
using Rentaly.BusinessLayer.Constants;
using Rentaly.DtoLayer.CategoryDtos;

namespace Rentaly.BusinessLayer.ValidationRules.CategoryValidations
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.CategoryName)
                .NotEmpty().WithMessage(ErrorMessages.CategoryNameRequired)
                .MinimumLength(2).WithMessage(ErrorMessages.CategoryNameLength)
                .MaximumLength(50).WithMessage(ErrorMessages.CategoryNameLength);
        }
    }
}
