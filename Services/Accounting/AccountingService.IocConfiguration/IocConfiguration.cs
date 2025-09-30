using Microsoft.Extensions.DependencyInjection;
using AccountingService.Application.Services.Account;
using AccountingService.Application.Services.Mapping;
using AccountingService.Application.Services.Permission;
using AccountingService.Application.Services.Role;
using AccountingService.Application.Services.User;
using AccountingService.Application.Services.UserPermission;
using AccountingService.ApplicationContract.Interfaces;
using AccountingService.ApplicationContract.Interfaces.Account;
using AccountingService.ApplicationContract.Interfaces.Permission;
using AccountingService.ApplicationContract.Interfaces.Role;
using AccountingService.ApplicationContract.Interfaces.UserPermission;
using AccountingService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using AccountingService.Infrastructure.EntityFrameWorkCore.Repository.Command.Account;
using AccountingService.Infrastructure.EntityFrameWorkCore.Repository.Command.Permission;
using AccountingService.Infrastructure.EntityFrameWorkCore.Repository.Command.Role;
using AccountingService.Infrastructure.EntityFrameWorkCore.Repository.Command.UserPermission;
using AccountingService.Infrastructure.EntityFrameWorkCore.Repository.Query.Account;
using AccountingService.Infrastructure.EntityFrameWorkCore.Repository.Query.Permission;
using AccountingService.Infrastructure.EntityFrameWorkCore.Repository.Query.Role;
using AccountingService.Infrastructure.EntityFrameWorkCore.Repository.Query.UserPermission;
using AccountingService.Infrastructure.EntityFrameWorkCore.UnitOfWork;
using AccountingService.InfrastructureContract.Interfaces;
using AccountingService.InfrastructureContract.Interfaces.Command.Account;
using AccountingService.InfrastructureContract.Interfaces.Command.Permission;
using AccountingService.InfrastructureContract.Interfaces.Command.Role;
using AccountingService.InfrastructureContract.Interfaces.Command.UserPermission;
using AccountingService.InfrastructureContract.Interfaces.Query.Account;
using AccountingService.InfrastructureContract.Interfaces.Query.Permission;
using AccountingService.InfrastructureContract.Interfaces.Query.Role;
using AccountingService.InfrastructureContract.Interfaces.Query.UserPermission;

namespace AccountingService.IocConfiguration
{
    public static class IocConfiguration
    {
        public static IServiceCollection ConfigureIoc(this IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>();
            services.AddAutoMapper(typeof(MappingApplication).Assembly);
            services.AddScoped<IAccountCommandRepository, AccountCommandRepository>();
            services.AddScoped<IAccountQueryRepository, AccountQueryRepository>();
            services.AddScoped<IRoleCommandRepository, RoleCommandRepository>();
            services.AddScoped<IRoleQueryRepository, RoleQueryRepository>();
            services.AddScoped<IPermissionCommandRepository, PermissionCommandRepository>();
            services.AddScoped<IPermissionQueryRepository, PermissionQueryRepository>();
            services.AddScoped<IUserPermissionCommandRepository, UserPermissionCommandRepository>();
            services.AddScoped<IUserPermissionQueryRepository, UserPermissionQueryRepository>();
            services.AddScoped<IAccountAppService, AccountAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IRoleAppService, RoleAppService>();
            services.AddScoped<IPermissionAppService, PermissionAppService>();
            services.AddScoped<IUserPermissionAppService, UserPermissionAppService>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            return services;
        }
    }
}
