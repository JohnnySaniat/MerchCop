using MerchCop.Models;
using Microsoft.EntityFrameworkCore;

namespace MerchCop.Requests
{
    public class Products
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/products", (MerchCopDbContext db) =>
            {
                return db.Products.ToList();
            });

            app.MapGet("/products/{productId}", (int productId, MerchCopDbContext db) =>
            {
                var product = db.Products.Find(productId);

                if (product == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(product);
            });

            app.MapDelete("/products/{productId}", (int productId, MerchCopDbContext db) =>
            {
                var product = db.Products.Find(productId);

                if (product == null)
                {
                    return Results.NotFound();
                }

                db.Products.Remove(product);
                db.SaveChanges();

                return Results.Ok();
            });

            app.MapPut("/products/{productId}", async (int productId, Product updatedProduct, MerchCopDbContext db) =>
            {
                var product = await db.Products.FindAsync(productId);

                if (product == null)
                {
                    return Results.NotFound();
                }

                product.ProductName = updatedProduct.ProductName;
                product.TypeId = updatedProduct.TypeId;
                product.Price = updatedProduct.Price;
                product.SellerId = updatedProduct.SellerId;
                product.IsSolvedText = updatedProduct.IsSolvedText;
                product.IsSolvedMathRandom = updatedProduct.IsSolvedMathRandom;
                product.IsSolvedArtistChallenge = updatedProduct.IsSolvedArtistChallenge;

                db.Products.Update(product);
                await db.SaveChangesAsync();

                return Results.Ok(product);
            });

            app.MapPost("/products", async (Product newProduct, MerchCopDbContext db) =>
            {
                await db.Products.AddAsync(newProduct);
                await db.SaveChangesAsync();

                return Results.Created($"/products/{newProduct.Id}", newProduct);
            });

            app.MapPut("/products/{productId}/is-staging", async (int productId, bool isStaging, MerchCopDbContext db) =>
            {
                var product = await db.Products.FindAsync(productId);

                if (product == null)
                {
                    return Results.NotFound();
                }

                product.IsStaging = isStaging;

                db.Products.Update(product);
                await db.SaveChangesAsync();

                return Results.Ok(product);
            });

            app.MapPut("/products/{productId}/is-solved-text", async (int productId, bool isSolvedText, MerchCopDbContext db) =>
            {
                var product = await db.Products.FindAsync(productId);

                if (product == null)
                {
                    return Results.NotFound();
                }

                product.IsSolvedText = isSolvedText;

                db.Products.Update(product);
                await db.SaveChangesAsync();

                return Results.Ok(product);
            });

            app.MapPut("/products/{productId}/is-solved-math-random", async (int productId, bool isSolvedMathRandom, MerchCopDbContext db) =>
            {
                var product = await db.Products.FindAsync(productId);

                if (product == null)
                {
                    return Results.NotFound();
                }

                product.IsSolvedMathRandom = isSolvedMathRandom;

                db.Products.Update(product);
                await db.SaveChangesAsync();

                return Results.Ok(product);
            });

            app.MapPut("/products/{productId}/is-solved-artist-challenge", async (int productId, bool isSolvedArtistChallenge, MerchCopDbContext db) =>
            {
                var product = await db.Products.FindAsync(productId);

                if (product == null)
                {
                    return Results.NotFound();
                }

                product.IsSolvedArtistChallenge = isSolvedArtistChallenge;

                db.Products.Update(product);
                await db.SaveChangesAsync();

                return Results.Ok(product);
            });

            app.MapGet("/products/user/{sellerId}", async (int sellerId, MerchCopDbContext db) =>
            {
                var products = await db.Products
                    .Include(p => p.Seller)
                    .Where(p => p.SellerId == sellerId)
                    .ToListAsync();

                if (products == null || !products.Any())
                {
                    return Results.NotFound();
                }

                return Results.Ok(products);
            });

        }

    }
}
