using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMicroservice.Core.Entities;

public class Product
{
    public int Id { get; set; }

    [MaxLength(100)]
    [Column(TypeName = "nvarchar(100)")] // Explicitly storing as nvarchar(100)
    public string Name { get; set; }

    [MaxLength(500)]
    [Column(TypeName = "nvarchar(500)")] // Explicitly storing as nvarchar(500)
    public string Description { get; set; }

    public int CategoryId { get; set; }

    [Column(TypeName = "decimal(18,4)")] // 
    public decimal Price { get; set; }
    public int Qty { get; set; }

    public string ProductImage { get; set; }

    [MaxLength(50)]
    [Column(TypeName = "nvarchar(50)")] // Ensuring SKU is stored as nvarchar(50)
    public string SKU { get; set; }

    // Navigation Props
    public ICollection<ProductVariationValues> ProductVariationValues { get; set; } =
        new List<ProductVariationValues>();

    public ProductCategory ProductCategory { get; set; }
}