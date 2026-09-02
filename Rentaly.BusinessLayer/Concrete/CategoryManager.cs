using AutoMapper;
using FluentValidation;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.Exceptions;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;
using Rentaly.DtoLayer.CategoryDtos;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.BusinessLayer.Concrete
{
    public class CategoryManager : BaseManager, ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCategoryDto> _createValidator;
        private readonly IValidator<UpdateCategoryDto> _updateValidator;

        public CategoryManager(ICategoryDal categoryDal, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCategoryDto> createValidator, IValidator<UpdateCategoryDto> updateValidator) : base(unitOfWork)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task TDeleteAsync(int id)
        {
            var value = await _categoryDal.GetByIdAsync(id);

            if (value is null)
                throw new BusinessRuleException("Silinecek kategori bulunamadı.");

            await _categoryDal.DeleteAsync(id);
            await SaveAsync("Bu kategoriye ait araçlar olduğu için silinemedi.");
        }

        public async Task<GetCategoryByIdDto?> TGetByIdAsync(int id)
        {
            var value = await _categoryDal.GetByIdAsync(id);

            if (value is null)
                return null;

            return _mapper.Map<GetCategoryByIdDto>(value);
        }

        public async Task<List<ResultCategoryDto>> TGetListAsync()
        {
            var values = await _categoryDal.GetListAsync();

            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task TInsertAsync(CreateCategoryDto dto)
        {
            await _createValidator.ValidateOrThrowAsync(dto);

            var value = _mapper.Map<Category>(dto);

            await _categoryDal.InsertAsync(value);
            await SaveAsync();
        }

        public async Task TUpdateAsync(UpdateCategoryDto dto)
        {
            await _updateValidator.ValidateOrThrowAsync(dto);

            var value = await _categoryDal.GetByIdAsync(dto.CategoryId);

            if (value is null)
                throw new BusinessRuleException("Güncellenecek kategori bulunamadı.");

            _mapper.Map(dto, value);
            await SaveAsync();
        }
    }
}
