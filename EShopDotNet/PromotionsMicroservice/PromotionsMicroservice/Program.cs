using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.Core.Contracts.Interfaces;
using PromotionsMicroservice.Core.Contracts.Services;
using PromotionsMicroservice.Core.Helpers;
using PromotionsMicroservice.Infrastructure.Data;
using PromotionsMicroservice.Infrastructure.Repositories;
using PromotionsMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<PromotionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EcommercePromotions")));

builder.Services.AddScoped<IPromotionRepository, PromotionRepositoryAsync>();
builder.Services.AddScoped<IPromotionServiceAsync, PromotionServiceAsync>();






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