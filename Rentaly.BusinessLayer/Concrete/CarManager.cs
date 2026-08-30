using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.BusinessLayer.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IUnitOfWork _unitOfWork;

        public CarManager(ICarDal carDal, IUnitOfWork unitOfWork)
        {
            _carDal = carDal;
            _unitOfWork = unitOfWork;
        }

        public async Task TDeleteAsync(int id)
        {
            await _carDal.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Car>> TGetAllCarsWithCategoryAsync()
        {
            return await _carDal.GetAllCarsWithCategoryAsync();
        }

        public async Task<Car?> TGetByIdAsync(int id)
        {
            return await _carDal.GetByIdAsync(id);
        }

        public async Task<List<Car>> TGetListAsync()
        {
            return await _carDal.GetListAsync();
        }

        public async Task TInsertAsync(Car entity)
        {
            await _carDal.InsertAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TUpdateAsync(Car entity)
        {
            await _carDal.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
