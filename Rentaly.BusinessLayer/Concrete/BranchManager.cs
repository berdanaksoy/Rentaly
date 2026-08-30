using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rentaly.BusinessLayer.Concrete
{
    public class BranchManager : IBranchService
    {
        private readonly IBranchDal _branchDal;
        private readonly IUnitOfWork _unitOfWork;

        public BranchManager(IBranchDal branchDal, IUnitOfWork unitOfWork)
        {
            _branchDal = branchDal;
            _unitOfWork = unitOfWork;
        }

        public async Task TDeleteAsync(int id)
        {
            await _branchDal.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Branch?> TGetByIdAsync(int id)
        {
            return await _branchDal.GetByIdAsync(id);
        }

        public async Task<List<Branch>> TGetListAsync()
        {
            return await _branchDal.GetListAsync();
        }

        public async Task TInsertAsync(Branch entity)
        {
            await _branchDal.InsertAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TUpdateAsync(Branch entity)
        {
            await _branchDal.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
