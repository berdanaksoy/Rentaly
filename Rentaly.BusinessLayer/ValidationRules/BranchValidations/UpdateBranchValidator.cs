using FluentValidation;
using Rentaly.BusinessLayer.Constants;
using Rentaly.DtoLayer.BranchDtos;

namespace Rentaly.BusinessLayer.ValidationRules.BranchValidations
{
    public class UpdateBranchValidator:AbstractValidator<UpdateBranchDto>
    {
        public UpdateBranchValidator()
        {
            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("Şube ID boş geçilemez.");

            RuleFor(x => x.BranchName)
                .NotEmpty().WithMessage(ErrorMessages.BranchNameRequired)
                .MinimumLength(2).WithMessage(ErrorMessages.BranchNameLength)
                .MaximumLength(100).WithMessage(ErrorMessages.BranchNameLength);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(ErrorMessages.BranchAddressRequired)
                .MinimumLength(10).WithMessage(ErrorMessages.BranchAddressLength)
                .MaximumLength(200).WithMessage(ErrorMessages.BranchAddressLength);

            RuleFor(x => x.City)
                .NotEmpty().WithMessage(ErrorMessages.BranchCityRequired)
                .MinimumLength(2).WithMessage(ErrorMessages.BranchCityLength)
                .MaximumLength(100).WithMessage(ErrorMessages.BranchCityLength);
        }
    }
}
