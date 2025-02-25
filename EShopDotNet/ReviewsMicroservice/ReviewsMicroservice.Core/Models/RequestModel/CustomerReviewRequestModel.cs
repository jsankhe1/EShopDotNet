using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewsMicroservice.Core.Models.RequestModel;

public class CustomerReviewRequestModel
{
    public int Id { get; set; }
    
    public string? CustomerId { get; set; }
    [Required]
    [StringLength(256, ErrorMessage = "Name must be less than 256 and more thn 2", MinimumLength = 2),]
    public string? CustomerName { get; set; }
    
    public string OrderId { get; set; }
    
    [Required]
    public DateTime OrderDate { get; set; }
    
    public string? ProductId { get; set; }
    
    [Required]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "Product name must be between 2 and 255 characters.")]

    public string ProductName { get; set; }
    
    public decimal RatingValue { get; set; }
    
    [Required]
    [StringLength(500, MinimumLength = 2, ErrorMessage = "Comment must be between 2 and 500 characters.")]
    public string Comment { get; set; }

    [Required]
    public DateTime ReviewDate { get; set; } // Required, converting string to DateTime
}
    
