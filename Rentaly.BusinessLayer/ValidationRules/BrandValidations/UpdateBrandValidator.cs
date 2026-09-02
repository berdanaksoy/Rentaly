using FluentValidation;
using Rentaly.DtoLayer.BrandDtos;

namespace Rentaly.BusinessLayer.ValidationRules.BrandValidations
{
    public class UpdateBrandValidator : AbstractValidator<UpdateBrandDto>
    {
        public UpdateBrandValidator()
        {
            RuleFor(x => x.BrandId)
                .GreaterThan(0).WithMessage("Geçerli bir marka seçilmelidir");

            RuleFor(x => x.BrandName)
                .NotEmpty().WithMessage("Marka adı boş geçilemez")
                .MinimumLength(2).WithMessage("Marka adı en az 2 karakter olmalıdır")
                .MaximumLength(50).WithMessage("Marka adı en fazla 50 karakter olabilir");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Marka görseli boş geçilemez");
        }
    }
}