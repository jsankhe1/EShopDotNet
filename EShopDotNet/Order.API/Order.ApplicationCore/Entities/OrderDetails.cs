namespace Order.ApplicationCore.Entities;

public class OrderDetails
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    
    // Navigation Props
    public Order Order { get; set; } = null!;
}