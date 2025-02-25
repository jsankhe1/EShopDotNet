using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PromotionsMicroservice.Core.Entities;

public class Promotion
{

    public int Id { get; set; } // Likely auto-incremented by DB

    [Required]
    [MaxLength(256)]
    [Column(TypeName = "nvarchar(256)")]
    public string Name { get; set; }

    [Required]
    [MaxLength(500)]
    [Column(TypeName = "nvarchar(500)")]
    public string Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    [Range(0.01, 100, ErrorMessage = "Discount must be between 0.01 and 100")]
    public decimal Discount { get; set; }

    [Required]
    public DateTime StartDate { get; set; }


    [Required]
    public DateTime EndDate { get; set; }
    
        
    // Navigation Props

    public ICollection<PromotionDetails> PromotionDetails { get; set; }
}