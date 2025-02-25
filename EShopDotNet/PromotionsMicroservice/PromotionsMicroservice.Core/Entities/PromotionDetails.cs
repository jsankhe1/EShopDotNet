using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionsMicroservice.Core.Entities;

public class PromotionDetails
{
    public int Id { get; set; }
    public int PromotionId { get; set; }
    public int PromotionCategoryId { get; set; }
    
    [Column(TypeName = "nvarchar(100)")]
    public string ProductCategoryName { get; set; }
    
    // Navigation Props
    public Promotion Promotion { get; set; }
    
}