using System.Collections;

namespace Order.ApplicationCore.Entities;

public class PaymentType
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Navigation Props
    public ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
}