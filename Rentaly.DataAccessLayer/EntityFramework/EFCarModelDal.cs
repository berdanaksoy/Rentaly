using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.Concrete;
using Rentaly.DataAccessLayer.RepositoryDesignPattern;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.EntityFramework
{
    public class EFCarModelDal : GenericRepository<CarModel>, ICarModelDal
    {
        public EFCarModelDal(RentalyContext context) : base(context)
        {
        }
    }
}
