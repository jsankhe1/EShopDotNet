using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entities;


namespace Order.Infrastructure.Data;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
        
        
    }
    
    // Order Management
    public DbSet<ApplicationCore.Entities.Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }

    // Customer Management
    public DbSet<Customer> Customers { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<Address> Addresses { get; set; }

    // Shopping Cart
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    // Payment
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        // Order -> OrderDetails (One-to-Many)
        modelBuilder.Entity<OrderDetails>()
            .HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId);
        
        
        modelBuilder.Entity<ApplicationCore.Entities.Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

       
        
        modelBuilder.Entity<UserAddress>()
            .HasOne(ua => ua.Customer)
            .WithMany(c => c.UserAddresses)
            .HasForeignKey(ua => ua.CustomerId);
        
        modelBuilder.Entity<UserAddress>()
            .HasOne(ua => ua.Address)
            .WithMany(a => a.Addresses)
            .HasForeignKey(ua => ua.AddressId);
        

        modelBuilder.Entity<ShoppingCart>()
            .HasOne(c => c.Customer)
            .WithMany(c => c.ShoppingCarts)
            .HasForeignKey(c => c.CustomerId);
       
        modelBuilder.Entity<ShoppingCartItem>()
            .HasOne(i => i.ShoppingCart)
            .WithMany(c => c.ShoppingCartItems)
            .HasForeignKey(i => i.CartID);

        modelBuilder.Entity<PaymentMethod>()
            .HasOne(m => m.PaymentType)
            .WithMany(t => t.PaymentMethods)
            .HasForeignKey(m => m.PaymentTypeId);



        // Order Table Configuration

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
        
        // OrderDetails Table Config
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

        // Address Table Configuration
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Street1).HasMaxLength(255).IsRequired();
            entity.Property(e => e.Street2).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Zipcode).HasMaxLength(20).IsRequired();
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100).IsRequired();
        });
        // Customer Table Configuration
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.ProfilePic).HasMaxLength(255);
            entity.Property(e => e.UserId).IsRequired();
        });
        // Shopping Cart Table Configuration
        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CustomerId).IsRequired();
            entity.Property(e => e.CustomerName).HasMaxLength(100).IsRequired();
        });
        
        
        // ShoppingCartItem Table Configuration
        modelBuilder.Entity<ShoppingCartItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CartID).IsRequired();
            entity.Property(e => e.ProductId).IsRequired();
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.Quantity).IsRequired();
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
        });
        
        // PaymentType Table Configuration
        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
        });

        // PaymentMethod Table Configuration
        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PaymentTypeId).IsRequired();
            entity.Property(e => e.Provider).HasMaxLength(100).IsRequired();
            entity.Property(e => e.AccountNumber).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Expiry).HasColumnType("datetime");
            entity.Property(e => e.IsDefault).IsRequired();
        });
        
        
    }
}