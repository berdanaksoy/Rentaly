using Microsoft.EntityFrameworkCore;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.Concrete;
using Rentaly.DataAccessLayer.Filters;
using Rentaly.DataAccessLayer.RepositoryDesignPattern;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.EntityFramework
{
    public class EFCarDal : GenericRepository<Car>, ICarDal
    {
        public EFCarDal(RentalyContext context) : base(context)
        {
        }

        public async Task<List<Car>> GetListWithRelationsAsync()
        {
            return await _context.Cars
                .Include(x => x.CarModel).ThenInclude(x => x.Brand)
                .Include(x => x.CarModel).ThenInclude(x => x.Category)
                .Include(x => x.Branch)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Car>> GetFilteredListAsync(CarFilter filter)
        {
            var query = _context.Cars
                .Include(x => x.CarModel).ThenInclude(x => x.Brand)
                .Include(x => x.CarModel).ThenInclude(x => x.Category)
                .Include(x => x.Branch)
                .AsNoTracking()
                .AsQueryable();

            if (filter.BrandId.HasValue)
                query = query.Where(x => x.CarModel.BrandId == filter.BrandId.Value);

            if (filter.CategoryId.HasValue)
                query = query.Where(x => x.CarModel.CategoryId == filter.CategoryId.Value);

            if (filter.BranchId.HasValue)
                query = query.Where(x => x.BranchId == filter.BranchId.Value);

            if (filter.MinPrice.HasValue)
                query = query.Where(x => x.DailyPrice >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(x => x.DailyPrice <= filter.MaxPrice.Value);

            if (filter.IsActive.HasValue)
                query = query.Where(x => x.IsActive == filter.IsActive.Value);

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                var term = filter.SearchTerm.Trim();
                query = query.Where(x =>
                    x.PlateNumber.Contains(term) ||
                    x.CarModel.ModelName.Contains(term) ||
                    x.CarModel.Brand.BrandName.Contains(term));
            }

            return await query.OrderByDescending(x => x.CarId).ToListAsync();
        }
    }
}