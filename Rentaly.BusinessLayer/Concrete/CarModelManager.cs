using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.BusinessLayer.Concrete
{
    public class CarModelManager : ICarModelService
    {
        private readonly ICarModelDal _carModelDal;
        private readonly IUnitOfWork _unitOfWork;

        public CarModelManager(ICarModelDal carModelDal, IUnitOfWork unitOfWork)
        {
            _carModelDal = carModelDal;
            _unitOfWork = unitOfWork;
        }

        public async Task TDeleteAsync(int id)
        {
            await _carModelDal.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CarModel?> TGetByIdAsync(int id)
        {
            return await _carModelDal.GetByIdAsync(id);
        }

        public async Task<List<CarModel>> TGetListAsync()
        {
            return await _carModelDal.GetListAsync();
        }

        public async Task TInsertAsync(CarModel entity)
        {
            await _carModelDal.InsertAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TUpdateAsync(CarModel entity)
        {
            await _carModelDal.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
