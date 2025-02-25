using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMicroservice.Core.Entities;

public class ProductCategory
{
    public int Id { get; set; }
    [MaxLength(100)]
    [Column(TypeName = "nvarchar(100)")] // Explicitly storing as nvarchar(100)
    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }


    // Navigation Props
    public ProductCategory? ParentCategory { get; set; } //self referential link
    public ICollection<ProductCategory> SubCategories { get; set; } = new List<ProductCategory>(); // Inverse
    
    
    public ICollection<CategoryVariation> CategoryVariations { get; set; } = new List<CategoryVariation>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}