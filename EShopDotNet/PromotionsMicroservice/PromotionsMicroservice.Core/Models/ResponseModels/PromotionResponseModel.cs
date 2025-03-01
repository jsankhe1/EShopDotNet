using PromotionsMicroservice.Core.Entities;
using System.Text.Json.Serialization;
using PromotionsMicroservice.Core.Entities;

namespace PromotionsMicroservice.Core.Models.ResponseModels
{
    public class PromotionResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]

        public PromotionState PromotionState { get; set; }
    }
}