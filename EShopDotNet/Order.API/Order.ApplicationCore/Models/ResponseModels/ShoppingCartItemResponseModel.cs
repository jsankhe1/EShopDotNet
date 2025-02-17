namespace Order.ApplicationCore.Models.ResponseModels;

public class ShoppingCartItemResponseModel
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
}