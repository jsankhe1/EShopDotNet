using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewsMicroservice.Core.Entities;

public class CustomerReview
{
    public int Id { get; set; }
    
    public string? CustomerId { get; set; }
    
    [Column(TypeName = "varchar(100)")]
    public string CustomerName { get; set; }
    
    public int OrderId { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public int ProductId { get; set; }
    
    [Column(TypeName = "nvarchar(100)")]
    public string ProductName { get; set; }
    
    public decimal RatingValue { get; set; }
    
    [Column(TypeName = "nvarchar(100)")]
    public string Comment { get; set; }
    
    public DateTime ReviewDate { get; set; }
    
    
}