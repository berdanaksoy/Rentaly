using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.Abstract
{
    public interface ICarModelDal : IGenericDal<CarModel>
    {
        Task<List<CarModel>> GetListWithRelationsAsync();
    }
}