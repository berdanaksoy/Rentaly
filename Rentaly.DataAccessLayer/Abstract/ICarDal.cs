using Rentaly.DataAccessLayer.Filters;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.Abstract
{
    public interface ICarDal : IGenericDal<Car>
    {
        Task<List<Car>> GetListWithRelationsAsync();
        Task<List<Car>> GetFilteredListAsync(CarFilter filter);
    }
}