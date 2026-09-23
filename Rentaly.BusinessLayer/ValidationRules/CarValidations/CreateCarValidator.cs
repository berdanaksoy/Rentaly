using FluentValidation;
using Rentaly.BusinessLayer.Constants;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DtoLayer.CarDtos;

namespace Rentaly.BusinessLayer.ValidationRules.CarValidations
{
    public class CreateCarValidator : AbstractValidator<CreateCarDto>
    {
        private readonly ICarDal _carDal;

        public CreateCarValidator(ICarDal carDal)
        {
            _carDal = carDal;

            RuleFor(x => x.PlateNumber)
                .NotEmpty().WithMessage(ErrorMessages.CarPlateRequired)
                .Matches(@"^(0[1-9]|[1-7][0-9]|8[01])[A-Z]{1,3}\d{2,5}$")
                    .WithMessage(ErrorMessages.CarPlateFormat)
                .MustAsync(BeUniquePlateAsync).WithMessage(ErrorMessages.CarPlateAlreadyExists);

            RuleFor(x => x.VIN)
                .NotEmpty().WithMessage(ErrorMessages.CarVinRequired)
                .Length(17).WithMessage(ErrorMessages.CarVinLength)
                .Matches("^[A-HJ-NPR-Z0-9]{17}$").WithMessage(ErrorMessages.CarVinFormat)
                .MustAsync(BeUniqueVinAsync).WithMessage(ErrorMessages.CarVinAlreadyExists);

            RuleFor(x => x.CarModelId)
                .GreaterThan(0).WithMessage(ErrorMessages.CarModelRequired);

            RuleFor(x => x.BranchId)
                .GreaterThan(0).WithMessage(ErrorMessages.CarBranchRequired);

            RuleFor(x => x.Year)
                .InclusiveBetween(1990, DateTime.Now.Year + 1).WithMessage(ErrorMessages.CarYearInvalid);

            RuleFor(x => x.Kilometer)
                .GreaterThanOrEqualTo(0).WithMessage(ErrorMessages.CarKilometerInvalid);

            RuleFor(x => x.DailyPrice)
                .GreaterThan(0).WithMessage(ErrorMessages.CarDailyPriceInvalid);

            RuleFor(x => x.DepositAmount)
                .GreaterThanOrEqualTo(0).WithMessage(ErrorMessages.CarDepositInvalid);

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage(ErrorMessages.CarImageRequired)
                .MaximumLength(300).WithMessage(ErrorMessages.CarImageLength);

            RuleFor(x => x.SeatCount)
                .InclusiveBetween(1, 12).WithMessage(ErrorMessages.CarSeatCountInvalid);

            RuleFor(x => x.LuggageCount)
                .GreaterThanOrEqualTo(0).WithMessage(ErrorMessages.CarLuggageInvalid);

            RuleFor(x => x.FuelType)
                .IsInEnum().WithMessage(ErrorMessages.CarFuelTypeInvalid);

            RuleFor(x => x.Transmission)
                .IsInEnum().WithMessage(ErrorMessages.CarTransmissionInvalid);
        }

        private async Task<bool> BeUniquePlateAsync(string plateNumber, CancellationToken token)
        {
            return !await _carDal.AnyAsync(x => x.PlateNumber == plateNumber);
        }

        private async Task<bool> BeUniqueVinAsync(string vin, CancellationToken token)
        {
            return !await _carDal.AnyAsync(x => x.VIN == vin);
        }
    }
}