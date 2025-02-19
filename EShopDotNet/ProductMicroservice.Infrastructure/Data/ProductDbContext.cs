using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Core.Entities;

namespace ProductMicroservice.Infrastructure.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options): base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public CategoryVariation CategoryVariations { get; set; }
    public ProductCategory ProductCategories { get; set; }
    public VariationValue VariationValues { get; set; }
    public ProductVariationValues ProductVariationValues { get; set; }

}