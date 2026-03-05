using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.Concrete;
using Rentaly.DataAccessLayer.RepositoryDesignPattern;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rentaly.DataAccessLayer.EntityFramework
{
    public class EFCategoryDal:GenericRepository<Category>, ICategoryDal
    {
        public EFCategoryDal(RentalyContext context) : base(context)
        {
        }
    }
}
