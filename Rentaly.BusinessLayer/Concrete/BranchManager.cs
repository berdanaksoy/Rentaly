using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.Exceptions;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;
using Rentaly.DtoLayer.BranchDtos;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.BusinessLayer.Concrete
{
    public class BranchManager : BaseManager, IBranchService
    {
        private readonly IBranchDal _branchDal;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBranchDto> _createValidator;
        private readonly IValidator<UpdateBranchDto> _updateValidator;

        public BranchManager(
            IBranchDal branchDal,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<CreateBranchDto> createValidator,
            IValidator<UpdateBranchDto> updateValidator) : base(unitOfWork)
        {
            _branchDal = branchDal;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<List<ResultBranchDto>> TGetListAsync()
        {
            var values = await _branchDal.GetListAsync();
            return _mapper.Map<List<ResultBranchDto>>(values);
        }

        public async Task<GetBranchByIdDto?> TGetByIdAsync(int id)
        {
            var value = await _branchDal.GetByIdAsync(id);

            if (value is null)
                return null;

            return _mapper.Map<GetBranchByIdDto>(value);
        }

        public async Task TInsertAsync(CreateBranchDto dto)
        {
            await _createValidator.ValidateOrThrowAsync(dto);

            var value = _mapper.Map<Branch>(dto);
            await _branchDal.InsertAsync(value);
            await SaveAsync();
        }

        public async Task TUpdateAsync(UpdateBranchDto dto)
        {
            await _updateValidator.ValidateOrThrowAsync(dto);

            var value = await _branchDal.GetByIdAsync(dto.BranchId);

            if (value is null)
                throw new BusinessRuleException("Güncellenecek şube bulunamadı.");

            _mapper.Map(dto, value);
            await SaveAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var value = await _branchDal.GetByIdAsync(id);

            if (value is null)
                throw new BusinessRuleException("Silinecek şube bulunamadı.");

            await _branchDal.DeleteAsync(id);
            await SaveAsync("Bu şubeye bağlı araç veya rezervasyon olduğu için silinemedi.");
        }
    }
}