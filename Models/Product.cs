namespace MerchCop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int TypeId { get; set; }
        public decimal Price { get; set; }
        public int CollaboratorId { get; set; }

        public string Image {  get; set; }

        public bool IsStaging { get; set; }
        public bool IsSolvedText { get; set; }
        public bool IsSolvedMathRandom { get; set; }
        public bool IsSolvedArtistChallenge { get; set; }

        public ICollection<Order> Orders { get; set; }
        
    }
}
