using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Core.Entities;

namespace ProductMicroservice.Infrastructure.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Product { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<CategoryVariation> CategoryVariations { get; set; }
    public DbSet<VariationValue> VariationValues { get; set; }
    public DbSet<ProductVariationValues> ProductVariationValues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // set constraints
        // Product-ProductCategory relationship (Many-to-One)
        modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductCategory)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Self-referencing relationship for ProductCategory (Parent-Child categories)
        modelBuilder.Entity<ProductCategory>()
            .HasOne(p => p.ParentCategory)
            .WithMany(pc => pc.SubCategories)
            .HasForeignKey(pc => pc.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // category variation to product category (many to one)
        modelBuilder.Entity<CategoryVariation>()
            .HasOne(cv => cv.ProductCategory)
            .WithMany(pc => pc.CategoryVariations)
            .HasForeignKey(cv => cv.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // variation value to Catefory Variations (many to one)
        modelBuilder.Entity<VariationValue>()
            .HasOne(vv => vv.CategoryVariation)
            .WithMany(cv => cv.VariationValues)
            .HasForeignKey(vv => vv.VariationId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // ProductVariationValues values to Variation values (many to one)
        modelBuilder.Entity<ProductVariationValues>()
            .HasOne(pvv => pvv.VariationValue)
            .WithMany(vv => vv.ProductVariationValues)
            .HasForeignKey(pvv => pvv.VariationValueId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // composite primary key created from junction table of product to variation values
        // Many-to-Many relationship between Product and VariationValue
        modelBuilder.Entity<ProductVariationValues>()
            .HasKey(pvv => new
            {
                pvv.ProductId, pvv.VariationValueId
            });

        
        // ProductVariationValues values to Product (many to one)
        modelBuilder.Entity<ProductVariationValues>()
            .HasOne(pvv => pvv.Product)
            .WithMany(p => p.ProductVariationValues)
            .HasForeignKey(pvv => pvv.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        
        

    }
}