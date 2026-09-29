using AutoMapper;
using FluentValidation;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.Exceptions;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;
using Rentaly.DtoLayer.CustomerDtos;

namespace Rentaly.BusinessLayer.Concrete
{
    public class CustomerManager : BaseManager, ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateCustomerDto> _updateValidator;

        public CustomerManager(
            ICustomerDal customerDal,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<UpdateCustomerDto> updateValidator) : base(unitOfWork)
        {
            _customerDal = customerDal;
            _mapper = mapper;
            _updateValidator = updateValidator;
        }

        public async Task<List<ResultCustomerDto>> TGetListAsync()
        {
            var values = await _customerDal.GetListAsync();
            return _mapper.Map<List<ResultCustomerDto>>(values);
        }

        public async Task<GetCustomerByIdDto?> TGetByIdAsync(int id)
        {
            var value = await _customerDal.GetByIdAsync(id);

            if (value is null)
                return null;

            return _mapper.Map<GetCustomerByIdDto>(value);
        }

        public async Task TUpdateAsync(UpdateCustomerDto dto)
        {
            dto.Phone = NormalizePhone(dto.Phone);
            dto.Email = dto.Email?.Trim() ?? string.Empty;

            await _updateValidator.ValidateOrThrowAsync(dto);

            var value = await _customerDal.GetByIdAsync(dto.CustomerId);

            if (value is null)
                throw new BusinessRuleException("Güncellenecek müşteri bulunamadı.");

            _mapper.Map(dto, value);
            await SaveAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var value = await _customerDal.GetByIdAsync(id);

            if (value is null)
                throw new BusinessRuleException("Silinecek müşteri bulunamadı.");

            await _customerDal.DeleteAsync(id);
            await SaveAsync("Bu müşteriye ait rezervasyonlar olduğu için silinemedi.");
        }

        private static string NormalizePhone(string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return string.Empty;

            return new string(phone.Where(char.IsDigit).ToArray());
        }
    }
}