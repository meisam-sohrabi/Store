using Microsoft.OpenApi.Models;
using SataService.Application.Services.Captcha;
using SataService.Application.Services.OTP;
using SataService.ApplicationContract.Interfaces;
using SataService.IocConfig;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpClient<IOTPAppService, OTPAppService>();
builder.Services.AddHttpClient<ICaptchaAppService,CaptchaAppService>();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
