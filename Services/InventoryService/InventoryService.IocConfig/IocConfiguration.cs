using Microsoft.Extensions.DependencyInjection;
//using ShopService.Application.Services.Mapping;
using InventoryService.Application.Services.RabbitMq;
using InventoryService.ApplicationContract.Interfaces.RabbitMq;
using InventoryService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using InventoryService.Infrastructure.EntityFrameWorkCore.Repository.Command.ProductInventory;
using InventoryService.Infrastructure.EntityFrameWorkCore.UnitOfWork;
using InventoryService.InfrastructureContract.Interfaces.Command.ProductInventory;
using InventoryService.InfrastructureContract.Interfaces;
using InventoryService.ApplicationContract.Interfaces.ProductInventory;
using InventoryService.Application.Services.ProductInventory;
namespace InventoryService.IocConfig
{
    public static class IocConfiguration
    {
        public static IServiceCollection ConfigureIoc(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            //services.AddAutoMapper(typeof(MappingApplication).Assembly);
            services.AddScoped<IProductInventoryCommandRepository, ProductInventoryCommandRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IRabbitMqAppService, RabbitMqAppService>();
            services.AddScoped<IProductInventoryAppService, ProductInventoryAppService>();
            return services;
        }
    }
}
