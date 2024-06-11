namespace MerchCop.Models
{
    public class Collaborator
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public string Testimony { get; set; }

        public string Instagram { get; set; }

        public string Website { get; set; }

        public string AdditionalLink { get; set; }

        public string Charity { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}