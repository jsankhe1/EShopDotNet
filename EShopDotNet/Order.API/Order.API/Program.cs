using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Interfaces;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Helpers;
using Order.Infrastructure.Data;
using Order.Infrastructure.Repositories;
using Order.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrderDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("EcommOrders"))); //Injecting DbContext.

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();
builder.Services.AddAutoMapper(typeof(ApplicationMapper));
builder.Services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();