namespace ProductMicroservice.Core.Entities;

public class ProductCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }


    // Navigation Props
    public ProductCategory? ParentCategory { get; set; } //self referential link
    public ICollection<ProductCategory> SubCategories { get; set; } = new List<ProductCategory>(); // Inverse
    
    
    public ICollection<CategoryVariation> CategoryVariations { get; set; } = new List<CategoryVariation>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}