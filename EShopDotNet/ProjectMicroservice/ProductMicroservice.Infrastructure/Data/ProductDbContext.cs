using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Core.Entities;

namespace ProductMicroservice.Infrastructure.Data;

public class ProductDbContext : DbContext
{
    
    public ProductDbContext(DbContextOptions<ProductDbContext> options): base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<CategoryVariation> CategoryVariations { get; set; }
    public DbSet<VariationValue> VariationValues { get; set; }
    public DbSet<ProductVariationValues> ProductVariationValues { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // set constraints
    }

}