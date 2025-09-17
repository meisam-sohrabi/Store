using First.Application.Services.Internal.Account;
using First.Application.Services.Internal.Category;
using First.Application.Services.Internal.CategoryWithProduct;
using First.Application.Services.Internal.Product;
using First.InfrastructureContract.Interfaces.Internal.Authentication;
using First.InfrastructureContract.Interfaces.Internal.Category;
using First.InfrastructureContract.Interfaces.Internal.CategoryWithProduct;
using First.InfrastructureContract.Interfaces.Internal.Product;
using Microsoft.Extensions.DependencyInjection;

namespace First.IocConfig
{
    public static class IocConfiguration
    {
        public static IServiceCollection ConfigureIoc(this IServiceCollection services)
        {
            services.AddScoped<IProductApi,ProductAppService>();
            services.AddScoped<ICategoryApi,CategoryAppService>();
            services.AddScoped<IAuthentication,AuthAppService>();
            services.AddScoped<ICategoryWithProductApi,CategoryWithProductAppService>();
            return services;
        }
    }
}
