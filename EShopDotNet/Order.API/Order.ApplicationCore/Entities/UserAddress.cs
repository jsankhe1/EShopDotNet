namespace Order.ApplicationCore.Entities;

public class UserAddress
{
    public int Id { get; set; }
    public int CustomerId { get; set; } // Foreign Key
    public int AddressId { get; set; } // Foreign Key
    public bool IsDefaultAddress { get; set; }

    // Navigation properties
    public Customer Customer { get; set; }
    public Address Address { get; set; }
}