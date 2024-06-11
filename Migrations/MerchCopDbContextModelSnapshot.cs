﻿// <auto-generated />
using System;
using MerchCop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MerchCop.Migrations
{
    [DbContext(typeof(MerchCopDbContext))]
    partial class MerchCopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MerchCop.Models.Collaborator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Charity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Instagram")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Testimony")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Collaborators");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdditionalLink = "https://example.com",
                            Charity = "Charity1",
                            Image = "https://example.com/john.jpg",
                            Instagram = "@johndoe",
                            Name = "John Doe",
                            Testimony = "Great collaborator!",
                            Website = "https://johndoe.com"
                        },
                        new
                        {
                            Id = 2,
                            AdditionalLink = "https://example.com",
                            Charity = "Charity2",
                            Image = "https://example.com/jane.jpg",
                            Instagram = "@janesmith",
                            Name = "Jane Smith",
                            Testimony = "Wonderful work!",
                            Website = "https://janesmith.com"
                        });
                });

            modelBuilder.Entity("MerchCop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsComplete")
                        .HasColumnType("boolean");

                    b.Property<string>("PaymentType")
                        .HasColumnType("text");

                    b.Property<int?>("ProductTypeId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Total")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("TotalWithTax")
                        .HasColumnType("numeric");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsComplete = true,
                            PaymentType = "Credit",
                            ProductTypeId = 1,
                            Total = 0m,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsComplete = false,
                            PaymentType = "Debit",
                            ProductTypeId = 2,
                            Total = 0m,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("MerchCop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CollaboratorId")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsSolvedArtistChallenge")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSolvedMathRandom")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSolvedText")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsStaging")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CollaboratorId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CollaboratorId = 1,
                            Image = "https://letsenhance.io/static/8f5e523ee6b2479e26ecc91b9c25261e/1015f/MainAfter.jpg",
                            IsSolvedArtistChallenge = false,
                            IsSolvedMathRandom = false,
                            IsSolvedText = false,
                            IsStaging = true,
                            Price = 100m,
                            ProductName = "Shrugbo",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CollaboratorId = 1,
                            Image = "https://letsenhance.io/static/8f5e523ee6b2479e26ecc91b9c25261e/1015f/MainAfter.jpg",
                            IsSolvedArtistChallenge = false,
                            IsSolvedMathRandom = false,
                            IsSolvedText = false,
                            IsStaging = false,
                            Price = 150m,
                            ProductName = "Trenboodoo",
                            TypeId = 2
                        },
                        new
                        {
                            Id = 3,
                            CollaboratorId = 2,
                            Image = "https://letsenhance.io/static/8f5e523ee6b2479e26ecc91b9c25261e/1015f/MainAfter.jpg",
                            IsSolvedArtistChallenge = false,
                            IsSolvedMathRandom = false,
                            IsSolvedText = false,
                            IsStaging = false,
                            Price = 50m,
                            ProductName = "Salad",
                            TypeId = 3
                        });
                });

            modelBuilder.Entity("MerchCop.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Type1"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Type2"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Type3"
                        });
                });

            modelBuilder.Entity("MerchCop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSeller")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            Email = "gertyherdy@example.com",
                            FirstName = "Darbin",
                            Image = "https://avatarfiles.alphacoders.com/113/113469.jpg",
                            IsAdmin = true,
                            IsSeller = true,
                            LastName = "Glowbone",
                            Uid = "WFKkg9zIyfT36VTlUrxbLXhknJV2",
                            UserName = "200201"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St",
                            Email = "goober@example.com",
                            FirstName = "Phil",
                            Image = "https://imagedelivery.net/9sCnq8t6WEGNay0RAQNdvQ/UUID-cl9g4rv6p4471q8nfruthlmio/public",
                            IsAdmin = false,
                            IsSeller = false,
                            LastName = "Doctor",
                            Uid = "WFKkg9zIyfT36VTlUrxbLXhknJV3",
                            UserName = "200202"
                        });
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductsId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("MerchCop.Models.Order", b =>
                {
                    b.HasOne("MerchCop.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId");

                    b.HasOne("MerchCop.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("MerchCop.Models.Product", b =>
                {
                    b.HasOne("MerchCop.Models.Collaborator", null)
                        .WithMany("Products")
                        .HasForeignKey("CollaboratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("MerchCop.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MerchCop.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MerchCop.Models.Collaborator", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MerchCop.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
