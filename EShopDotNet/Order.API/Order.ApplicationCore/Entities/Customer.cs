namespace Order.ApplicationCore.Entities;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Phone { get; set; }
    public string ProfilePic { get; set; }
    public int UserId { get; set; }

    
    //Navigation Properties
    public ICollection<UserAddress> UserAddresses = new List<UserAddress>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}