namespace Order.ApplicationCore.Entities;

public class PaymentMethod
{
    public int Id { get; set; }
    public int PaymentTypeId { get; set; }
    public string Provider { get; set; }
    public string AccountType { get; set; }
    public string AccountNumber { get; set; }
    public string Expiry { get; set; }
    public bool IsDefault { get; set; }

    
//Navigation Props
    public PaymentType PaymentType { get; set; }

    
}