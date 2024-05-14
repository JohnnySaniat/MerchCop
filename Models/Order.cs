﻿namespace MerchCop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SellerId { get; set; }
        public bool IsComplete { get; set; }
        public int PaymentTypeId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
