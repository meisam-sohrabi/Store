using LogEngine;
using Microsoft.Extensions.DependencyInjection;
using Second.Application.Services.Account;
using Second.Application.Services.Auth;
using Second.Application.Services.Category;
using Second.Application.Services.CategoryWithProduct;
using Second.Application.Services.Cookie;
using Second.Application.Services.Product;
using Second.ApplicationContract.Interfaces;
using Second.ApplicationContract.Mapping;
using Second.Infrastructure.EntityFrameWorkCore.AppDbContext;
using Second.Infrastructure.EntityFrameWorkCore.Repository.Command.Account;
using Second.Infrastructure.EntityFrameWorkCore.Repository.Command.Auth;
using Second.Infrastructure.EntityFrameWorkCore.Repository.Command.Category;
using Second.Infrastructure.EntityFrameWorkCore.Repository.Command.Product;
using Second.Infrastructure.EntityFrameWorkCore.Repository.Command.Security;
using Second.Infrastructure.EntityFrameWorkCore.Repository.Command.Session;
using Second.Infrastructure.EntityFrameWorkCore.Repository.Query.Account;
using Second.Infrastructure.EntityFrameWorkCore.Repository.Query.Auth;
using Second.Infrastructure.EntityFrameWorkCore.Repository.Query.Category;
using Second.Infrastructure.EntityFrameWorkCore.Repository.Query.PermissionManagement;
using Second.Infrastructure.EntityFrameWorkCore.Repository.Query.Product;
using Second.Infrastructure.EntityFrameWorkCore.Repository.Query.Security;
using Second.Infrastructure.EntityFrameWorkCore.Repository.Query.Session;
using Second.Infrastructure.EntityFrameWorkCore.UnitOfWork;
using Second.InfrastructureContract.Interfaces;
using Second.InfrastructureContract.Interfaces.Command.Account;
using Second.InfrastructureContract.Interfaces.Command.Auth;
using Second.InfrastructureContract.Interfaces.Command.Category;
using Second.InfrastructureContract.Interfaces.Command.Product;
using Second.InfrastructureContract.Interfaces.Command.Security;
using Second.InfrastructureContract.Interfaces.Command.Session;
using Second.InfrastructureContract.Interfaces.Query.Account;
using Second.InfrastructureContract.Interfaces.Query.Auth;
using Second.InfrastructureContract.Interfaces.Query.Category;
using Second.InfrastructureContract.Interfaces.Query.PermisionManagement;
using Second.InfrastructureContract.Interfaces.Query.Product;
using Second.InfrastructureContract.Interfaces.Query.Security;
using Second.InfrastructureContract.Interfaces.Query.Session;
namespace Second.Ioc.Config
{
    public static class IocConfiguration
    {
        public static IServiceCollection ConfigureIoc(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddAutoMapper(typeof(MappingApplication).Assembly);
            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRespository, ProductQueryRepository>();
            services.AddScoped<IAccountCommandRepository, AccountCommandRepository>();
            services.AddScoped<IAccountQueryRepository, AccountQueryRepository>();
            services.AddScoped<IRefreshTokenCommandRepository, RefreshTokenCommandRepository>();
            services.AddScoped<IRefreshTokenQueryRepository, RefreshTokenQueryRepository>();
            services.AddScoped<IPermissionQueryRepository, PermissionQueryRepository>();
            services.AddScoped<IAuthCommandRepository, AuthCommandRepository>();
            services.AddScoped<IAuthQueryRepository, AuthQueryRepository>();
            services.AddScoped<ISessionCommandRepository,SessionCommandRepository>();
            services.AddScoped<ISessionQueryRepository,SessionQueryRepository>();
            services.AddScoped<ICookieService, CookieAppService>();
            services.AddScoped<ILogEngineAppService,LogEngineAppService>();
            services.AddScoped<CategoryAppService>();
            services.AddScoped<ProductAppService>();
            services.AddScoped<CategoryWithProductAppService>();
            services.AddScoped<AccountAppService>();
            services.AddScoped<AuthAppService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
