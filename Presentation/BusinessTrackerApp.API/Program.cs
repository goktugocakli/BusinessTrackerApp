using BusinessTrackerApp.Persistence;
using BusinessTrackerApp.Application;
using FluentValidation.AspNetCore;
using BusinessTrackerApp.API.Extensions;
using BusinessTrackerApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/* 
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("tr-TR");
});
*/

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices();
builder.Services.AddPersistanceServices();
builder.Services.AddApplicationServices();

builder.Services.AddHttpContextAccessor();

builder.Services.ConfigureJWT(builder.Configuration);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler<Program>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

