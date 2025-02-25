using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMicroservice.Core.Entities;

public class CategoryVariation
{
    public int Id { get; set; }
    public int CategoryId { get; set; }

    [MaxLength(100)]
    [Column(TypeName = "nvarchar(100)")] // Explicitly storing as nvarchar(100)
    public string VariationName { get; set; }
    // Navigation Props

    public ICollection<VariationValue> VariationValues { get; set; } = new List<VariationValue>();
    public ProductCategory ProductCategory { get; set; }
}