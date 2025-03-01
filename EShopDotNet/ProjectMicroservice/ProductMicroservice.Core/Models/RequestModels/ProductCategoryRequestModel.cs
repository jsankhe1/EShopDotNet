namespace ProductMicroservice.Core.Models.RequestModels
{
    public class ProductCategoryRequestModel
    {
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
