using AutoMapper;
using Rentaly.DtoLayer.BranchDtos;
using Rentaly.DtoLayer.BrandDtos;
using Rentaly.DtoLayer.CarDtos;
using Rentaly.DtoLayer.CarModelDtos;
using Rentaly.DtoLayer.CategoryDtos;
using Rentaly.DtoLayer.CustomerDtos;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.BusinessLayer.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Customer, ResultCustomerDto>();
            CreateMap<Customer, GetCustomerByIdDto>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>()
                .ForMember(d => d.CustomerId, o => o.Ignore());

            CreateMap<Brand, ResultBrandDto>();
            CreateMap<Brand, GetBrandByIdDto>();
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<GetBrandByIdDto, UpdateBrandDto>();
            CreateMap<UpdateBrandDto, Brand>()
                .ForMember(d => d.BrandId, o => o.Ignore());

            CreateMap<Branch, ResultBranchDto>();
            CreateMap<Branch, GetBranchByIdDto>();
            CreateMap<CreateBranchDto, Branch>();
            CreateMap<GetBranchByIdDto, UpdateBranchDto>();
            CreateMap<UpdateBranchDto, Branch>()
                .ForMember(d => d.BranchId, o => o.Ignore());

            CreateMap<Category, ResultCategoryDto>();
            CreateMap<Category, GetCategoryByIdDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<GetCategoryByIdDto, UpdateCategoryDto>();
            CreateMap<UpdateCategoryDto, Category>()
                .ForMember(d => d.CategoryId, o => o.Ignore());

            CreateMap<CarModel, GetCarModelByIdDto>();
            CreateMap<CreateCarModelDto, CarModel>();
            CreateMap<GetCarModelByIdDto, UpdateCarModelDto>();
            CreateMap<UpdateCarModelDto, CarModel>()
                .ForMember(d => d.CarModelId, o => o.Ignore());
            CreateMap<CarModel, ResultCarModelDto>()
                .ForMember(d => d.BrandName, o => o.MapFrom(s => s.Brand.BrandName))
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.CategoryName));

            CreateMap<Car, GetCarByIdDto>();
            CreateMap<CreateCarDto, Car>();
            CreateMap<GetCarByIdDto, UpdateCarDto>();
            CreateMap<UpdateCarDto, Car>()
                .ForMember(d => d.CarId, o => o.Ignore());
            CreateMap<Car, ResultCarDto>()
                .ForMember(d => d.BrandName, o => o.MapFrom(s => s.CarModel.Brand.BrandName))
                .ForMember(d => d.ModelName, o => o.MapFrom(s => s.CarModel.ModelName))
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.CarModel.Category.CategoryName))
                .ForMember(d => d.BranchName, o => o.MapFrom(s => s.Branch.BranchName));
        }
    }
}