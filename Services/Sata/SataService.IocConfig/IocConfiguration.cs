using Microsoft.Extensions.DependencyInjection;
using SataService.Application.Services.OTP;
using SataService.ApplicationContract.Interfaces;
namespace SataService.IocConfig
{
    public static class IocConfiguration
    {
        public static IServiceCollection ConfigureIoc(this IServiceCollection services)
        {
            services.AddScoped<IOTPAppService, OTPAppService>();
            return services;    
        }
    }
}
