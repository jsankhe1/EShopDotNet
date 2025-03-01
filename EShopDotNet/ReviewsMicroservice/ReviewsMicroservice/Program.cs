using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.Core.Contracts.Interfaces;
using ReviewsMicroservice.Core.Contracts.Services;
using ReviewsMicroservice.Core.Entities;
using ReviewsMicroservice.Core.Helpers;
using ReviewsMicroservice.Core.Models.RequestModel;
using ReviewsMicroservice.Infrastructure.Data;
using ReviewsMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ReviewDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceReviews")));


// DI for service and repo
builder.Services.AddScoped<ICustomerReviewRepository,ICustomerReviewRepository >();
builder.Services.AddScoped<ICustomerReviewServiceAsync, CustomerReviewServiceAsync>();








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