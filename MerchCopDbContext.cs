﻿using MerchCop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace MerchCop
{
    public class MerchCopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Collaborator> Collaborators { get; set; }

        public MerchCopDbContext(DbContextOptions<MerchCopDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { Id = 1, Uid = "WFKkg9zIyfT36VTlUrxbLXhknJV2", FirstName = "Darbin", LastName = "Glowbone", UserName = "200201", Address = "123 Main St", Email = "gertyherdy@example.com", IsSeller = true, Image = "https://avatarfiles.alphacoders.com/113/113469.jpg", IsAdmin = true },
                new User { Id = 2, Uid = "WFKkg9zIyfT36VTlUrxbLXhknJV3", FirstName = "Phil", LastName = "Doctor", UserName = "200202", Address = "456 Elm St", Email = "goober@example.com", IsSeller = false, Image = "https://imagedelivery.net/9sCnq8t6WEGNay0RAQNdvQ/UUID-cl9g4rv6p4471q8nfruthlmio/public", IsAdmin = false }
            });

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order { Id = 1, UserId = 1, IsComplete = true, PaymentType = "Credit", ProductTypeId = 1, Total = 0, },
                new Order { Id = 2, UserId = 2, IsComplete = false, PaymentType = "Debit", ProductTypeId = 2, Total = 0, }
            });

            modelBuilder.Entity<ProductType>().HasData(new ProductType[]
            {
                new ProductType { Id = 1, Type = "Type1" },
                new ProductType { Id = 2, Type = "Type2" },
                new ProductType { Id = 3, Type = "Type3" }
            });

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product { Id = 1, ProductName = "Shrugbo", TypeId = 1, Price = 100, CollaboratorId = 1, IsStaging = true, IsSolvedText = false, IsSolvedMathRandom = false, IsSolvedArtistChallenge = false, Image = "https://letsenhance.io/static/8f5e523ee6b2479e26ecc91b9c25261e/1015f/MainAfter.jpg" },
                new Product { Id = 2, ProductName = "Trenboodoo", TypeId = 2, Price = 150, CollaboratorId = 1, IsStaging = false, IsSolvedText = false, IsSolvedMathRandom = false, IsSolvedArtistChallenge = false, Image = "https://letsenhance.io/static/8f5e523ee6b2479e26ecc91b9c25261e/1015f/MainAfter.jpg" },
                new Product { Id = 3, ProductName = "Salad", TypeId = 3, Price = 50, CollaboratorId = 2, IsStaging = false, IsSolvedText = false, IsSolvedMathRandom = false, IsSolvedArtistChallenge = false, Image = "https://letsenhance.io/static/8f5e523ee6b2479e26ecc91b9c25261e/1015f/MainAfter.jpg" }
            });

            modelBuilder.Entity<Collaborator>().HasData(new Collaborator[]
            {
                new Collaborator { Id = 1, Name = "John Doe", Image = "https://example.com/john.jpg", Testimony = "Great collaborator!", Instagram = "@johndoe", Website = "https://johndoe.com", AdditionalLink = "https://example.com", Charity = "Charity1" },
                new Collaborator { Id = 2, Name = "Jane Smith", Image = "https://example.com/jane.jpg", Testimony = "Wonderful work!", Instagram = "@janesmith", Website = "https://janesmith.com", AdditionalLink = "https://example.com", Charity = "Charity2" }
            });
        }
    }
}

