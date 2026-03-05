using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.Concrete;
using Rentaly.DataAccessLayer.RepositoryDesignPattern;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rentaly.DataAccessLayer.EntityFramework
{
    public class EFCarModel : GenericRepository<CarModel>, ICarModelDal
    {
        public EFCarModel(RentalyContext context) : base(context)
        {
        }
    }
}
