namespace MerchCop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int SellerId { get; set; }
        public bool IsComplete { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? ProductTypeId { get; set; }

        public ICollection<Product> Products { get; set; }

        public PaymentType PaymentType { get; set; }
        public ProductType ProductType { get; set; } 
    }
}
