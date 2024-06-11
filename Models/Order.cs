namespace MerchCop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public bool IsComplete { get; set; }
        public string? PaymentType { get; set; }

        public decimal? Total { get; set; }
        public int? ProductTypeId { get; set; }

        public ICollection<Product> Products { get; set; }

        public ProductType ProductType { get; set; }

        public const decimal TaxRate = 0.07m;
        public decimal? TotalWithTax { get; set; }

        public void CalculateTotalWithTax()
        {
            if (Total.HasValue)
            {
                TotalWithTax = Math.Round(Total.Value * TaxRate, 2);
                Total += TotalWithTax;
            }
        }

        public decimal? CalculateTotal
        {
            get
            {
                if (Products != null && Products.Any())
                {
                    decimal? subtotal = Products.Sum(product => product.Price);
                    decimal? totalWithTax = subtotal * (1 + TaxRate); // Include tax
                    return totalWithTax;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
