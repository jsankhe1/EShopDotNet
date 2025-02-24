using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductMicroservice.Core.Contracts.Interfaces;
using ProductMicroservice.Core.Contracts.Services;
using ProductMicroservice.Core.Helpers;
using ProductMicroservice.Infrastructure.Data;
using ProductMicroservice.Infrastructure.Repositories;
using ProductMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// DI for DBContext
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceProducts")));

// DI for Repos and services
builder.Services.AddScoped<IProductRepositoryAsync, ProductRepository>();
builder.Services.AddScoped<IProductSerivceAsync, ProductServiceAsync>();

builder.Services.AddScoped<ICategoryRepositoryAsync, CategoryRepository>();
builder.Services.AddScoped<ICategorySerivceAsync, CategoryServiceAsync>();


builder.Services.AddScoped<ICategoryVariationRepository, CategoryVariationRepository>();
builder.Services.AddScoped<ICategoryVariationSerivceAsync, CategoryVariationServiceAsync>();


builder.Services.AddScoped<IProductVariationRepositoryAsync, ProductVariationRepository>();
builder.Services.AddScoped<IProductVariationSerivceAsync, ProductVariationServiceAsync>();

builder.Services.AddScoped<IVariationValueRepositoryAsync, VariationValueRepository>();
builder.Services.AddScoped<IVariationValueSerivceAsync, VariationValuesServiceAsync>();




builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ApplicationMapper));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();