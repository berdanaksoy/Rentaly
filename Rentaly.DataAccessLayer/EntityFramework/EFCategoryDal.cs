using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.Concrete;
using Rentaly.DataAccessLayer.RepositoryDesignPattern;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.EntityFramework
{
    public class EFCategoryDal:GenericRepository<Category>, ICategoryDal
    {
        public EFCategoryDal(RentalyContext context) : base(context)
        {
        }
    }
}
