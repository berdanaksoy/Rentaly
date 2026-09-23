using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.Concrete;
using Rentaly.DataAccessLayer.RepositoryDesignPattern;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.EntityFramework
{
    public class EFCustomerDal : GenericRepository<Customer>, ICustomerDal
    {
        public EFCustomerDal(RentalyContext context) : base(context)
        {
        }
    }
}
