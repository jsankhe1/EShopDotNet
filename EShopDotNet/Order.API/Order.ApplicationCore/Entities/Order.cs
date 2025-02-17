using System.ComponentModel.DataAnnotations;

namespace Order.ApplicationCore.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime? OrderDate { get; set; }
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public int PaymentMethodId { get; set; }
    public string? PaymentName { get; set; }
    public string? ShippingAddress { get; set; }
    public string? ShippingMethod { get; set; }
    public string? OrderStatus { get; set; }
    [Required(ErrorMessage = "Bill Amount can't be blank")]public decimal? BillAmount { get; set; }

    // Navigation Properties
    public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    public ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
    public Customer Customer { get; set; }
}