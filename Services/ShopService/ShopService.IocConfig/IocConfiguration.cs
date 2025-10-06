using LogService;
using Microsoft.Extensions.DependencyInjection;
using ShopService.Application.Services.Category;
using ShopService.Application.Services.Cookie;
using ShopService.Application.Services.Mapping;
using ShopService.Application.Services.Order;
using ShopService.Application.Services.Product;
using ShopService.Application.Services.ProductBrand;
using ShopService.Application.Services.ProductDetail;
using ShopService.Application.Services.ProductPrice;
using ShopService.Application.Services.User;
using ShopService.ApplicationContract.Interfaces;
using ShopService.ApplicationContract.Interfaces.Category;
using ShopService.ApplicationContract.Interfaces.Order;
using ShopService.ApplicationContract.Interfaces.Product;
using ShopService.ApplicationContract.Interfaces.ProductBrand;
using ShopService.ApplicationContract.Interfaces.ProductDetail;
using ShopService.ApplicationContract.Interfaces.ProductPrice;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Category;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Order;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Product;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.ProductBrand;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.ProductDetail;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.ProductInventory;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.ProductPrice;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Account;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Category;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Order;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Product;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.ProductBrand;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.ProductDetail;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.ProductPrice;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.UserPermission;
using ShopService.Infrastructure.EntityFrameWorkCore.UnitOfWork;
using ShopService.InfrastructureContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces.Command.Category;
using ShopService.InfrastructureContract.Interfaces.Command.Order;
using ShopService.InfrastructureContract.Interfaces.Command.Product;
using ShopService.InfrastructureContract.Interfaces.Command.ProductBrand;
using ShopService.InfrastructureContract.Interfaces.Command.ProductDetail;
using ShopService.InfrastructureContract.Interfaces.Command.ProductInventory;
using ShopService.InfrastructureContract.Interfaces.Command.ProductPrice;
using ShopService.InfrastructureContract.Interfaces.Query.Account;
using ShopService.InfrastructureContract.Interfaces.Query.Category;
using ShopService.InfrastructureContract.Interfaces.Query.Order;
using ShopService.InfrastructureContract.Interfaces.Query.Product;
using ShopService.InfrastructureContract.Interfaces.Query.ProductBrand;
using ShopService.InfrastructureContract.Interfaces.Query.ProductDetail;
using ShopService.InfrastructureContract.Interfaces.Query.ProductPrice;
using ShopService.InfrastructureContract.Interfaces.Query.UserPermission;
namespace ShopService.IocConfig
{
    public static class IocConfiguration
    {
        public static IServiceCollection ConfigureIoc(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddAutoMapper(typeof(MappingApplication).Assembly);
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IUserPermissionQueryRepository, UserPermissionQueryRepository>();
            services.AddScoped<IAccountQueryRepository, AccountQueryRepository>();
            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRespository, ProductQueryRepository>();
            services.AddScoped<IProductDetailCommandRepository, ProductDetailCommandRepository>();
            services.AddScoped<IProductBrandCommandRepository, ProductBrandCommandRepository>();
            services.AddScoped<IProductBrandQueryRepository, ProductBrandQueryRepository>();
            services.AddScoped<IProductDetailQueryRepository, ProductDetailQueryRepository>();
            services.AddScoped<IProductPriceCommandRepository, ProductPriceCommandRepository>();
            services.AddScoped<IProductPriceQueryRepository, ProductPriceQueryRepository>();
            services.AddScoped<IProductInventoryCommandRepository, ProductInventoryCommandRepository>();
            services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
            services.AddScoped<IOrderQueryRepository, OrderQueryRepository>();
            services.AddScoped<ICookieAppService, CookieAppService>();
            services.AddSingleton<ILogAppService, LogAppService>(); // log should be singleton
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IProductBrandAppService, ProductBrandAppService>();
            services.AddScoped<IProductDetailAppService, ProductDetailAppService>();
            services.AddScoped<IProductPriceAppService, ProductPriceAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
