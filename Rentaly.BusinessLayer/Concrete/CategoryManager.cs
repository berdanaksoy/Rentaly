using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(ICategoryDal categoryDal, IUnitOfWork unitOfWork)
        {
            _categoryDal = categoryDal;
            _unitOfWork = unitOfWork;
        }

        public async Task TDeleteAsync(int id)
        {
            await _categoryDal.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Category?> TGetByIdAsync(int id)
        {
            return await _categoryDal.GetByIdAsync(id);
        }

        public async Task<List<Category>> TGetListAsync()
        {
            return await _categoryDal.GetListAsync();
        }

        public async Task TInsertAsync(Category entity)
        {
            await _categoryDal.InsertAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TUpdateAsync(Category entity)
        {
            await _categoryDal.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
