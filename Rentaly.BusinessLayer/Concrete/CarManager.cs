using AutoMapper;
using FluentValidation;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.Exceptions;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;
using Rentaly.DtoLayer.CarDtos;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.BusinessLayer.Concrete
{
    public class CarManager : BaseManager, ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCarDto> _createValidator;
        private readonly IValidator<UpdateCarDto> _updateValidator;

        public CarManager(ICarDal carDal, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCarDto> createValidator, IValidator<UpdateCarDto> updateValidator) : base (unitOfWork)
        {
            _carDal = carDal;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task TDeleteAsync(int id)
        {
            var value =await _carDal.GetByIdAsync(id);

            if (value is null)
                throw new BusinessRuleException("Silinecek araç bulunamadı.");

            await _carDal.DeleteAsync(id);
            await SaveAsync("Bu araca ait kiralama kayıtları olduğu için silinemedi.");
        }

        public async Task<GetCarByIdDto?> TGetByIdAsync(int id)
        {
            var value = await _carDal.GetByIdAsync(id);

            if (value is null)
                throw new BusinessRuleException("Araç bulunamadı.");

            return _mapper.Map<GetCarByIdDto>(value);
        }

        public async Task<List<ResultCarDto>> TGetListAsync()
        {
            var values = await _carDal.GetListWithRelationsAsync();
            return _mapper.Map<List<ResultCarDto>>(values);
        }

        public async Task TInsertAsync(CreateCarDto dto)
        {
            dto.PlateNumber = NormalizePlate(dto.PlateNumber);
            dto.VIN = dto.VIN?.Trim().ToUpperInvariant() ?? string.Empty;

            await _createValidator.ValidateOrThrowAsync(dto);

            var value = _mapper.Map<Car>(dto);
            await _carDal.InsertAsync(value);
            await SaveAsync();
        }

        public async Task TUpdateAsync(UpdateCarDto dto)
        {
            dto.PlateNumber = NormalizePlate(dto.PlateNumber);
            dto.VIN = dto.VIN?.Trim().ToUpperInvariant() ?? string.Empty;

            await _updateValidator.ValidateOrThrowAsync(dto);

            var value = await _carDal.GetByIdAsync(dto.CarId);

            if (value is null)
                throw new BusinessRuleException("Güncellenecek araç bulunamadı.");

            _mapper.Map(dto, value);
            await SaveAsync();
        }

        private static string NormalizePlate(string? plate)
        {
            if (string.IsNullOrWhiteSpace(plate))
                return string.Empty;

            return new string(plate.Where(char.IsLetterOrDigit).ToArray()).ToUpperInvariant();
        }
    }
}
