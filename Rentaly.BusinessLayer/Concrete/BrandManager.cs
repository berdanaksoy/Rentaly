using FluentValidation;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.ValidationRules;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.BusinessLayer.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IUnitOfWork _unitOfWork;

        public BrandManager(IBrandDal brandDal, IUnitOfWork unitOfWork)
        {
            _brandDal = brandDal;
            _unitOfWork = unitOfWork;
        }

        public async Task TDeleteAsync(int id)
        {
            await _brandDal.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Brand?> TGetByIdAsync(int id)
        {
            return await _brandDal.GetByIdAsync(id);
        }

        public async Task<List<Brand>> TGetListAsync()
        {
            return await _brandDal.GetListAsync();
        }

        public async Task TInsertAsync(Brand entity)
        {
            var validator = new BrandValidator();
            var result = validator.Validate(entity);

            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException(errors);
            }

            await _brandDal.InsertAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TUpdateAsync(Brand entity)
        {
            await _brandDal.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}