namespace ProductMicroservice.Core.Entities;

public class VariationValue
{
    public int Id { get; set; }
    public int VariationId { get; set; }
    public string Value { get; set; }
    // Navigation Props
    public CategoryVariation CategoryVariation { get; set; }

    public ICollection<ProductVariationValues> ProductVariationValues { get; set; } =
        new List<ProductVariationValues>();

}