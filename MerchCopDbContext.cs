using MerchCop.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MerchCop
{
    public class MerchCopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }

        public MerchCopDbContext(DbContextOptions<MerchCopDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sample data for User
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { Id = 1, Uid = "WFKkg9zIyfT36VTlUrxbLXhknJV2", FirstName = "Darbin", LastName = "Glowbone", UserName = "200201", Address = "123 Main St", Email = "gertyherdy@example.com", IsSeller = true, Image = "https://avatarfiles.alphacoders.com/113/113469.jpg" },
                new User { Id = 2, Uid = "WFKkg9zIyfT36VTlUrxbLXhknJV3", FirstName = "Phil", LastName = "Doctor", UserName = "200202", Address = "456 Elm St", Email = "goober@example.com", IsSeller = false, Image = "https://imagedelivery.net/9sCnq8t6WEGNay0RAQNdvQ/UUID-cl9g4rv6p4471q8nfruthlmio/public" }
            });

            // Sample data for Order
            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order { Id = 1001, UserId = 1, SellerId = "seller1", IsComplete = true, PaymentTypeId = 1 },
                new Order { Id = 1002, UserId = 2, SellerId = "seller2", IsComplete = false, PaymentTypeId = 2 }
            });

            // Sample data for PaymentType
            modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
            {
                new PaymentType { Id = 1, Category = "Credit" },
                new PaymentType { Id = 2, Category = "Cash" }
            });

            // Sample data for ProductType
            modelBuilder.Entity<ProductType>().HasData(new ProductType[]
            {
                new ProductType { Id = 1, Type = "Type1" },
                new ProductType { Id = 2, Type = "Type2" },
                new ProductType { Id = 3, Type = "Type3" }
            });

            // Sample data for Product
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product { Id = 101, ProductName = "Shrugbo", TypeId = 1, Price = 100, SellerId = 1, IsSolvedText = false, IsSolvedMathRandom = false, IsSolvedArtistChallenge = false },
                new Product { Id = 102, ProductName = "Trenboodoo", TypeId = 2, Price = 150, SellerId = 1, IsSolvedText = false, IsSolvedMathRandom = false, IsSolvedArtistChallenge = false },
                new Product { Id = 103, ProductName = "Salad", TypeId = 3, Price = 50, SellerId = 2, IsSolvedText = false, IsSolvedMathRandom = false, IsSolvedArtistChallenge = false }
            });
        }
    }
};


