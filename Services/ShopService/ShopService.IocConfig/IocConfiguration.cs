using LogService;
using Microsoft.Extensions.DependencyInjection;
using ShopService.Application.Services.Account;
using ShopService.Application.Services.Auth;
using ShopService.Application.Services.Category;
using ShopService.Application.Services.Cookie;
using ShopService.Application.Services.Product;
using ShopService.ApplicationContract.Interfaces;
using ShopService.Application.Services.Mapping;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Account;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Auth;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Category;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Product;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Security;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Session;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Account;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Auth;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Category;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.PermissionManagement;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Product;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Security;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Session;
using ShopService.Infrastructure.EntityFrameWorkCore.UnitOfWork;
using ShopService.InfrastructureContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces.Command.Account;
using ShopService.InfrastructureContract.Interfaces.Command.Auth;
using ShopService.InfrastructureContract.Interfaces.Command.Category;
using ShopService.InfrastructureContract.Interfaces.Command.Product;
using ShopService.InfrastructureContract.Interfaces.Command.Security;
using ShopService.InfrastructureContract.Interfaces.Command.Session;
using ShopService.InfrastructureContract.Interfaces.Query.Account;
using ShopService.InfrastructureContract.Interfaces.Query.Auth;
using ShopService.InfrastructureContract.Interfaces.Query.Category;
using ShopService.InfrastructureContract.Interfaces.Query.PermisionManagement;
using ShopService.InfrastructureContract.Interfaces.Query.Product;
using ShopService.InfrastructureContract.Interfaces.Query.Security;
using ShopService.InfrastructureContract.Interfaces.Query.Session;
using ShopService.Application.Services.User;
using ShopService.InfrastructureContract.Interfaces.Command.ProductDetail;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.ProductDetail;
using ShopService.InfrastructureContract.Interfaces.Command.ProductBrand;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.ProductBrand;
using ShopService.Application.Services.Transactions.Product;
using ShopService.InfrastructureContract.Interfaces.Query.ProductBrand;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.ProductBrand;
using ShopService.InfrastructureContract.Interfaces.Query.ProductDetail;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.ProductDetail;
using ShopService.Application.Services.ProductBrand;
using ShopService.Application.Services.ProductDetail;
using ShopService.ApplicationContract.Interfaces.Category;
using ShopService.ApplicationContract.Interfaces.Product;
using ShopService.ApplicationContract.Interfaces.ProductBrand;
using ShopService.ApplicationContract.Interfaces.ProductDetail;
using ShopService.ApplicationContract.Interfaces.Transactions.Product;
using ShopService.ApplicationContract.Interfaces.Account;
using ShopService.ApplicationContract.Interfaces.Atuh;
namespace ShopService.IocConfig
{
    public static class IocConfiguration
    {
        public static IServiceCollection ConfigureIoc(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddAutoMapper(typeof(MappingApplication).Assembly);
            services.AddScoped<IUserAppService, UserAppService>();  
            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRespository, ProductQueryRepository>();
            services.AddScoped<IProductDetailCommanRepository, ProductDetailCommandRepository>();
            services.AddScoped<IProductBrandCommandRepository, ProductBrandCommandRepository>();
            services.AddScoped<IProductBrandQueryRepository, ProductBrandQueryRepository>();
            services.AddScoped<IProductDetailQueryRepository, ProductDetailQueryRepository>();
            services.AddScoped<IAccountCommandRepository, AccountCommandRepository>();
            services.AddScoped<IAccountQueryRepository, AccountQueryRepository>();
            services.AddScoped<IRefreshTokenCommandRepository, RefreshTokenCommandRepository>();
            services.AddScoped<IRefreshTokenQueryRepository, RefreshTokenQueryRepository>();
            services.AddScoped<IPermissionQueryRepository, PermissionQueryRepository>();
            services.AddScoped<IAuthCommandRepository, AuthCommandRepository>();
            services.AddScoped<IAuthQueryRepository, AuthQueryRepository>();
            services.AddScoped<ISessionCommandRepository,SessionCommandRepository>();
            services.AddScoped<ISessionQueryRepository,SessionQueryRepository>();
            services.AddScoped<ICookieAppService, CookieAppService>();
            services.AddScoped<ILogAppService, LogAppService>();
            services.AddScoped<ICategoryAppService,CategoryAppService>();
            services.AddScoped<IProductAppService,ProductAppService>();
            services.AddScoped<IProductBrandAppService,ProductBrandAppService>();
            services.AddScoped<IProductDetailAppService,ProductDetailAppService>();
            services.AddScoped<IProductTransactionAppService,ProductTransactionAppService>();
            services.AddScoped<IAccountAppService,AccountAppService>();
            services.AddScoped<IAuthAppService,AuthAppService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
