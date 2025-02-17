using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entities;


namespace Order.Infrastructure.Data;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
        
        
    }
    
    DbSet<ApplicationCore.Entities.Order> Orders { get; set; }
    DbSet<OrderDetails> OrderDetails { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<OrderDetails>()
            .HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId);
        
        
        modelBuilder.Entity<ApplicationCore.Entities.Order>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).IsRequired();
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.PaymentMethodId).IsRequired();
            entity.Property(e => e.PaymentName).HasMaxLength(100);
            entity.Property(e => e.ShippingAddress).HasMaxLength(500);
            entity.Property(e => e.ShippingMethod).HasMaxLength(100);
            entity.Property(e => e.OrderStatus).HasMaxLength(100);
            entity.Property(e => e.BillAmount).HasColumnType("decimal(18,2)");
        });
        
        modelBuilder.Entity<OrderDetails>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.OrderId).IsRequired();
            entity.Property(e => e.ProductId).IsRequired();
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.Quantity).IsRequired();
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Discount).HasColumnType("decimal(18,2)");
        });
        

    }
}