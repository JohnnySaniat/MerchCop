namespace MerchCop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public bool IsSeller { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
