﻿namespace ProductMicroservice.Core.Models.ResponseModel
{
    public class ProductCategoryResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
