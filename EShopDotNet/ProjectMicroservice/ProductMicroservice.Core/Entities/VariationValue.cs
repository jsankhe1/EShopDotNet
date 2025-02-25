using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMicroservice.Core.Entities;

public class VariationValue
{
    public int Id { get; set; }
    public int VariationId { get; set; }
    
    [MaxLength(100)]
    [Column(TypeName = "nvarchar(100)")] // Explicitly storing as nvarchar(100)
    public string Value { get; set; }
    // Navigation Props
    public CategoryVariation CategoryVariation { get; set; }

    public ICollection<ProductVariationValues> ProductVariationValues { get; set; } =
        new List<ProductVariationValues>();

}