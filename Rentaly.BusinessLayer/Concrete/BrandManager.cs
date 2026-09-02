using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.Exceptions;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;
using Rentaly.DtoLayer.BrandDtos;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.BusinessLayer.Concrete
{
    public class BrandManager : BaseManager, IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBrandDto> _createValidator;
        private readonly IValidator<UpdateBrandDto> _updateValidator;

        public BrandManager(IBrandDal brandDal, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateBrandDto> createValidator, IValidator<UpdateBrandDto> updateValidator) : base(unitOfWork)
        {
            _brandDal = brandDal;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<List<ResultBrandDto>> TGetListAsync()
        {
            var values = await _brandDal.GetListAsync();

            return _mapper.Map<List<ResultBrandDto>>(values);
        }

        public async Task<GetBrandByIdDto?> TGetByIdAsync(int id)
        {
            var value = await _brandDal.GetByIdAsync(id);

            if (value is null)
                return null;

            return _mapper.Map<GetBrandByIdDto>(value);
        }

        public async Task TInsertAsync(CreateBrandDto dto)
        {
            await _createValidator.ValidateOrThrowAsync(dto);

            var value = _mapper.Map<Brand>(dto);

            await _brandDal.InsertAsync(value);
            await SaveAsync();
        }

        public async Task TUpdateAsync(UpdateBrandDto dto)
        {
            await _updateValidator.ValidateOrThrowAsync(dto);

            var value = await _brandDal.GetByIdAsync(dto.BrandId);

            if (value is null)
                throw new BusinessRuleException("Güncellenecek marka bulunamadı.");

            _mapper.Map(dto, value);
            await SaveAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var value = await _brandDal.GetByIdAsync(id);

            if (value is null)
                throw new BusinessRuleException("Silinecek marka bulunamadı.");

            await _brandDal.DeleteAsync(id);
            await SaveAsync();
        }
    }
}