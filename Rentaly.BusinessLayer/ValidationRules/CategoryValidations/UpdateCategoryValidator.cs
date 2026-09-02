using FluentValidation;
using Rentaly.BusinessLayer.Constants;
using Rentaly.DtoLayer.CategoryDtos;

namespace Rentaly.BusinessLayer.ValidationRules.CategoryValidations
{
    public class UpdateCategoryValidator:AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(c => c.CategoryId).NotEmpty().WithMessage("Geçerli bir kategori seçilmelidir.");
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage(ErrorMessages.CategoryNameRequired);
            RuleFor(c => c.CategoryName).MinimumLength(2).WithMessage(ErrorMessages.CategoryNameLength).MaximumLength(50).WithMessage(ErrorMessages.CategoryNameLength);
        }
    }
}
