using Microsoft.EntityFrameworkCore;
using Rentaly.BusinessLayer.Exceptions;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;

namespace Rentaly.BusinessLayer.Concrete
{
    public abstract class BaseManager
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async Task SaveAsync(string errorMessage = "Kayıt veritabanına yazılamadı. Lütfen tekrar deneyin.")
        {
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new BusinessRuleException(errorMessage);
            }
        }
    }
}