using System.Collections;

namespace Order.ApplicationCore.Entities;

public class ShoppingCart
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    
    
    //Navigation Props

    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    public Customer Customer { get; set; }
}