using Microsoft.OpenApi.Models;
using SataService.Application.Services.Auth;
using SataService.Application.Services.Prescription;
using SataService.ApplicationContract.Interfaces.Auth;
using SataService.ApplicationContract.Interfaces.Prescription;
using SataService.IocConfig;
namespace SataService.Api.Helper
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddHttpClient<IAuthAppService, AuthAppService>();
            builder.Services.AddHttpClient<IPrescriptionAppService, PrescriptionAppService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.ConfigureIoc();
            builder.Services.AddSwaggerGen(document =>
            {
                document.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Sata.Api",
                    Version = "v1",
                    Description = "",
                    Contact = new OpenApiContact
                    {
                        Name = "",
                        Email = "",
                    },
                });
            });

            return builder.Build();
        }

        public static WebApplication ConfigurePipelines(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
