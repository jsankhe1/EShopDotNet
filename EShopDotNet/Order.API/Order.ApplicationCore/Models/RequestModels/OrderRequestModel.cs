namespace Order.ApplicationCore.Models.RequestModels;

public class OrderRequestModel
{
        public int Id { get; set; }  //  Required to identify the order
        public DateTime? OrderDate { get; set; }
        public int CustomerId { get; set; }  //  
        public string? CustomerName { get; set; }
        public string? PaymentName { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ShippingMethod { get; set; }
        public decimal? BillAmount { get; set; }
        public string? OrderStatus { get; set; }
}
