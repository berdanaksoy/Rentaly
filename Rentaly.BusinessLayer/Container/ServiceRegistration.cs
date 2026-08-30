using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rentaly.BusinessLayer.Abstract;
using Rentaly.BusinessLayer.Concrete;
using Rentaly.BusinessLayer.Mapping;
using Rentaly.DataAccessLayer.Abstract;
using Rentaly.DataAccessLayer.Concrete;
using Rentaly.DataAccessLayer.EntityFramework;
using Rentaly.DataAccessLayer.UnitOfWorkDesignPattern;

namespace Rentaly.BusinessLayer.Container
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRentalyServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RentalyContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RentalyConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBranchDal, EFBranchDal>();
            services.AddScoped<IBranchService, BranchManager>();

            services.AddScoped<IBrandDal, EFBrandDal>();
            services.AddScoped<IBrandService, BrandManager>();

            services.AddScoped<ICarDal, EFCarDal>();
            services.AddScoped<ICarService, CarManager>();

            services.AddScoped<ICarModelDal, EFCarModelDal>();
            services.AddScoped<ICarModelService, CarModelManager>();

            services.AddScoped<ICategoryDal, EFCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<ICustomerDal, EFCustomerDal>();
            services.AddScoped<ICustomerService, CustomerManager>();

            services.AddScoped<IRentalDal, EFRentalDal>();
            services.AddScoped<IRentalService, RentalManager>();

            services.AddAutoMapper(typeof(GeneralMapping).Assembly);

            return services;
        }
    }
}