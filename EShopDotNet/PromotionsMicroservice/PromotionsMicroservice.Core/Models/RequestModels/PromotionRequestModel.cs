using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionsMicroservice.Core.Models.RequestModels;

public class PromotionRequestModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(256, ErrorMessage = "Name must be less than 256")]
    [MinLength(2, ErrorMessage = "Name must be more than 2")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "Name must be less than 500")]
    [MinLength(0)]
    public string Description { get; set; }

    [Required]
    [Range(0.01, 100, ErrorMessage = "Discount must be between 0.01 and 100.")]
    public decimal Discount { get; set; }

    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime EndDate { get; set; }
}