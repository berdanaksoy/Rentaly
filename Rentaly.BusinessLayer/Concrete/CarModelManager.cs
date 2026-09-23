using AutoMapper;
using FluentValidation;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.Exceptions;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;
using Rentaly.DtoLayer.CarModelDtos;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.BusinessLayer.Concrete
{
    public class CarModelManager : BaseManager, ICarModelService
    {
        private readonly ICarModelDal _carModelDal;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCarModelDto> _createValidator;
        private readonly IValidator<UpdateCarModelDto> _updateValidator;

        public CarModelManager(ICarModelDal carModelDal, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCarModelDto> createValidator, IValidator<UpdateCarModelDto> updateValidator) : base (unitOfWork)
        {
            _carModelDal = carModelDal;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task TDeleteAsync(int id)
        {
            var value = await _carModelDal.GetByIdAsync(id);

            if (value is null)
                throw new BusinessRuleException("Silinecek model bulunamadı.");

            await _carModelDal.DeleteAsync(id);
            await SaveAsync("Bu modele ait araçlar olduğu için silinemedi.");
        }

        public async Task<GetCarModelByIdDto?> TGetByIdAsync(int id)
        {
            var value = await _carModelDal.GetByIdAsync(id);

            if (value is null)
                return null;

            return _mapper.Map<GetCarModelByIdDto>(value);
        }

        public async Task<List<ResultCarModelDto>> TGetListAsync()
        {
            var values = await _carModelDal.GetListWithRelationsAsync();
            return _mapper.Map<List<ResultCarModelDto>>(values);
        }

        public async Task TInsertAsync(CreateCarModelDto dto)
        {
            await _createValidator.ValidateOrThrowAsync(dto);

            var value = _mapper.Map<CarModel>(dto);

            await _carModelDal.InsertAsync(value);
            await SaveAsync();
        }

        public async Task TUpdateAsync(UpdateCarModelDto dto)
        {
            await _updateValidator.ValidateOrThrowAsync(dto);

            var value = await _carModelDal.GetByIdAsync(dto.CarModelId);

            if (value is null)
                throw new BusinessRuleException("Güncellenecek model bulunamadı.");

            _mapper.Map(dto, value);
            await SaveAsync();
        }
    }
}
