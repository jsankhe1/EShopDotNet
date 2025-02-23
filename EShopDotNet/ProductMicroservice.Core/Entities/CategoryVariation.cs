namespace ProductMicroservice.Core.Entities;

public class CategoryVariation
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string VariationName { get; set; }
    // Navigation Props

    public ICollection<VariationValue> VariationValues { get; set; } = new List<VariationValue>();
    public ProductCategory ProductCategory { get; set; }
}