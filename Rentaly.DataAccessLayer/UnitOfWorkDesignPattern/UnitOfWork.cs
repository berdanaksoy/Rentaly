using Rentaly.DataAccessLayer.Concrete;

namespace Rentaly.DataAccessLayer.UnitOfWorkDesignPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentalyContext _context;

        public UnitOfWork(RentalyContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}