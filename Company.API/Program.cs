using CarInformation.API.Data;
using CarInformation.API.Features.Car.Controllers;
using CarInformation.API.Features.Car.Repositories;
using CarInformation.API.Features.Car.Repositories.Interface;
using CarInformation.API.Features.Company.Controllers;
using CarInformation.API.Features.Company.Repositories;
using CarInformation.API.Features.Company.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
    // ... other configuration options
});
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
string connection = configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<CompanyDbContext>(option => option.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI();

app.MapCompanyEndPoint();
app.MapCarEndPoint();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
