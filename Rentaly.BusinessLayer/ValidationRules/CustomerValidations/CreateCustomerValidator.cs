using FluentValidation;
using Rentaly.BusinessLayer.Constants;
using Rentaly.DtoLayer.CustomerDtos;

namespace Rentaly.BusinessLayer.ValidationRules.CustomerValidations
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(ErrorMessages.CustomerNameRequired)
                .MinimumLength(2).WithMessage(ErrorMessages.CustomerNameLength)
                .MaximumLength(50).WithMessage(ErrorMessages.CustomerNameLength);

            RuleFor(c => c.Surname)
                .NotEmpty().WithMessage(ErrorMessages.CustomerSurnameRequired)
                .MinimumLength(2).WithMessage(ErrorMessages.CustomerSurnameLength)
                .MaximumLength(50).WithMessage(ErrorMessages.CustomerSurnameLength);

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage(ErrorMessages.CustomerEmailRequired)
                .EmailAddress().WithMessage(ErrorMessages.InvalidEmail)
                .MaximumLength(100).WithMessage(ErrorMessages.CustomerEmailLength);

            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage(ErrorMessages.CustomerPhoneRequired)
                .Matches(@"^0?5\d{9}$").WithMessage(ErrorMessages.InvalidPhone);

            RuleFor(c => c.IdentityNumber)
                .NotEmpty().WithMessage(ErrorMessages.CustomerIdentityRequired)
                .Length(11).WithMessage(ErrorMessages.CustomerIdentityLength)
                .Matches(@"^\d{11}$").WithMessage(ErrorMessages.CustomerIdentityDigits);

            RuleFor(c => c.DrivingLicenseNumber)
                .NotEmpty().WithMessage(ErrorMessages.CustomerLicenseRequired)
                .MaximumLength(20).WithMessage(ErrorMessages.CustomerLicenseLength);

            RuleFor(c => c.DrivingLicenseDate)
                .LessThanOrEqualTo(DateTime.Today).WithMessage(ErrorMessages.CustomerLicenseDateFuture);
        }
    }
}

