using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.Concrete;
using Rentaly.DataAccessLayer.RepositoryDesignPattern;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.EntityFramework
{
    public class EFBrandDal : GenericRepository<Brand>, IBrandDal
    {
        public EFBrandDal(RentalyContext context) : base(context)
        {
        }
    }
}
