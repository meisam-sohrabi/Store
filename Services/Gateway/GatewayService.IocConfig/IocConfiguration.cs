using GatewayService.Application.Services.Auth;
using GatewayService.Application.Services.Cookie;
using GatewayService.Application.Services.User;
using GatewayService.ApplicationContract.Interfaces;
using GatewayService.ApplicationContract.Interfaces.Auth;
using GatewayService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using GatewayService.Infrastructure.EntityFrameWorkCore.Repository.Command.Security;
using GatewayService.Infrastructure.EntityFrameWorkCore.Repository.Command.Session;
using GatewayService.Infrastructure.EntityFrameWorkCore.Repository.Query.Auth;
using GatewayService.Infrastructure.EntityFrameWorkCore.Repository.Query.Role;
using GatewayService.Infrastructure.EntityFrameWorkCore.Repository.Query.Security;
using GatewayService.Infrastructure.EntityFrameWorkCore.Repository.Query.Session;
using GatewayService.Infrastructure.EntityFrameWorkCore.UnitOfWork;
using GatewayService.InfrastructureContract.Interfaces;
using GatewayService.InfrastructureContract.Interfaces.Command.Security;
using GatewayService.InfrastructureContract.Interfaces.Command.Session;
using GatewayService.InfrastructureContract.Interfaces.Query.Auth;
using GatewayService.InfrastructureContract.Interfaces.Query.Role;
using GatewayService.InfrastructureContract.Interfaces.Query.Security;
using GatewayService.InfrastructureContract.Interfaces.Query.Session;
using Microsoft.Extensions.DependencyInjection;

namespace GatewayService.IocConfig
{
    public static class IocConfiguration
    {
        public static IServiceCollection ConfigureIoc(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IAuthQueryRrepository, AuthQueryRepository>();
            services.AddScoped<IAuthAppService,AuthAppService>();
            services.AddScoped<IRoleQueryRepository ,RoleQueryRepository>();
            services.AddScoped<ISessionCommandRepository, SessionCommandRepository>();  
            services.AddScoped<ISessionQueryRepository, SessionQueryRepository>();  
            services.AddScoped<IRoleQueryRepository, RoleQueryRepository>();  
            services.AddScoped<ICookieAppService, CookieAppService>();  
            services.AddScoped<IRefreshTokenQueryRepository, RefreshTokenQueryRepository>();  
            services.AddScoped<IRefreshTokenCommandRepository, RefreshTokenCommandRepository>();  
            services.AddScoped<IUserAppService, UserAppService>();  
            services.AddScoped<IUnitOfWork, UnitOfWork>();  

            return services;
        }
    }
}
