namespace Rentaly.DataAccessLayer.UnitOfWorkDesignPattern
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}