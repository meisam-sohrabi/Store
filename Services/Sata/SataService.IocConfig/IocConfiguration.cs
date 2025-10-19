using Microsoft.Extensions.DependencyInjection;
using RedisService;
using SataService.Application.Services.Auth;
using SataService.Application.Services.Prescription;
using SataService.ApplicationContract.Interfaces.Auth;
using SataService.ApplicationContract.Interfaces.Prescription;
namespace SataService.IocConfig
{
    public static class IocConfiguration
    {
        public static IServiceCollection ConfigureIoc(this IServiceCollection services)
        {
            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IPrescriptionAppService,PrescriptionAppService>();
            services.AddScoped<ICacheAdapter, DistributedCacheAdapter>();
            return services;
        }
    }
}
