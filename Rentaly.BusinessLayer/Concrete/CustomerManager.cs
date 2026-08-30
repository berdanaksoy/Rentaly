using AutoMapper;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;
using Rentaly.DtoLayer.CustomerDtos;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rentaly.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerManager(ICustomerDal customerDal, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customerDal = customerDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task TDeleteAsync(int id)
        {
            await _customerDal.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetCustomerByIdDto> TGetByIdAsync(int id)
        {
            var value = await _customerDal.GetByIdAsync(id);
            return _mapper.Map<GetCustomerByIdDto>(value);
        }

        public async Task<List<ResultCustomerDto>> TGetListAsync()
        {
            var values = await _customerDal.GetListAsync();
            return _mapper.Map<List<ResultCustomerDto>>(values);
        }

        public async Task TInsertAsync(CreateCustomerDto dto)
        {
            var value = _mapper.Map<Customer>(dto);
            await _customerDal.InsertAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TUpdateAsync(CreateCustomerDto dto)
        {
            var value = _mapper.Map<Customer>(dto);
            await _customerDal.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
