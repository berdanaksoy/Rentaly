using AutoMapper;
using Rentaly.DtoLayer.BranchDtos;
using Rentaly.DtoLayer.BrandDtos;
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
                .ForMember(dest => dest.CustomerId, opt => opt.Ignore());

            CreateMap<Brand, ResultBrandDto>();
            CreateMap<Brand, GetBrandByIdDto>();
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<UpdateBrandDto, Brand>()
                .ForMember(dest => dest.BrandId, opt => opt.Ignore());

            CreateMap<Branch, ResultBranchDto>();
            CreateMap<Branch, GetBranchByIdDto>();
            CreateMap<CreateBranchDto, Branch>();
            CreateMap<UpdateBranchDto, Branch>()
                .ForMember(dest => dest.BranchId, opt => opt.Ignore());

            CreateMap<Category, ResultCategoryDto>();
            CreateMap<Category, GetCategoryByIdDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>()
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore());

            CreateMap<CarModel, GetCarModelByIdDto>();
            CreateMap<CreateCarModelDto, CarModel>();
            CreateMap<UpdateCarModelDto, CarModel>()
                .ForMember(dest => dest.CarModelId, opt => opt.Ignore());
            CreateMap<CarModel, ResultCarModelDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName));
        }
    }
}