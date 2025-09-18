using ApiCallService.Application.Services.Internal.Auth;
using ApiCallService.Application.Services.Internal.Category;
using ApiCallService.Application.Services.Internal.Product;
using ApiCallService.Application.Services.Internal.Transactions.Product;
using ApiCallService.ApplicationContract.Interfaces.Internal.Auth;
using ApiCallService.ApplicationContract.Interfaces.Internal.Category;
using ApiCallService.ApplicationContract.Interfaces.Internal.CategoryWithProduct;
using ApiCallService.ApplicationContract.Interfaces.Internal.Product;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCallService.IocConfig
{
    public static class IocConfiguration
    {
        public static IServiceCollection ConfigureIoc(this IServiceCollection services)
        {
            services.AddScoped<IProductAppService,ProductAppService>();
            services.AddScoped<ICategoryAppService,CategoryAppService>();
            services.AddScoped<IAuthenticationAppService,AuthAppService>();
            services.AddScoped<IProductTransactionAppService,ProductTransactionsAppService>();
            return services;
        }
    }
}
