namespace Order.ApplicationCore.Entities;

public class ShoppingCartItem
{
    public int Id { get; set; }
    public int CartID { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    
    
    //Navigation Props
    
    public ShoppingCart ShoppingCart { get; set; }

}