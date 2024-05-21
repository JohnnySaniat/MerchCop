using MerchCop.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace MerchCop.Requests
{
    public class Orders
    {
        public static void Map(WebApplication app)
        {

            app.MapGet("/orders", (MerchCopDbContext db) =>
            {
                return db.Orders
                    .Include(o => o.Products)
                    .Include(o => o.PaymentType)
                    .Include(o => o.ProductType)
                    .ToList();
            });

            app.MapGet("/orders/{orderId}", (int orderId, MerchCopDbContext db) =>
            {
                var order = db.Orders
                    .Include(o => o.Products)
                    .Include(o => o.PaymentType)
                    .Include(o => o.ProductType)
                    .SingleOrDefault(o => o.Id == orderId);

                if (order == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(order);
            });

            app.MapPut("/orders/{orderId}/complete", async (int orderId, int paymentTypeId, MerchCopDbContext db) =>
            {
                var order = await db.Orders.FindAsync(orderId);

                if (order == null)
                {
                    return Results.NotFound();
                }

                var paymentType = await db.PaymentTypes.FindAsync(paymentTypeId);

                if (paymentType == null)
                {
                    return Results.NotFound();
                }

                order.PaymentTypeId = paymentTypeId;

                order.IsComplete = true;

                db.Orders.Update(order);
                await db.SaveChangesAsync();

                return Results.Ok(order);
            });

            app.MapPost("/orders/{orderId}/products/{productId}", async (int orderId, int productId, MerchCopDbContext db) =>
            {
                var order = await db.Orders.FindAsync(orderId);

                if (order == null)
                {
                    return Results.NotFound($"Order with ID {orderId} not found.");
                }

                var product = await db.Products.FindAsync(productId);

                if (product == null)
                {
                    return Results.NotFound($"Product with ID {productId} not found.");
                }

                if (order.Products == null)
                {
                    order.Products = new List<Product>();
                }
                order.Products.Add(product);

                db.Orders.Update(order);
                await db.SaveChangesAsync();

                return Results.Created($"/orders/{order.Id}", order);
            });

            app.MapDelete("/orders/{orderId}/products/{productId}", (MerchCopDbContext db, int orderId, int productId) =>
            {
                var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == orderId);

                if (order == null)
                {
                    return Results.NotFound("Order not found.");
                }

                var productToRemove = order.Products.FirstOrDefault(p => p.Id == productId);

                if (productToRemove == null)
                {
                    return Results.NotFound("Product not found in cart.");
                }

                order.Products.Remove(productToRemove);

                db.SaveChanges();

                return Results.Ok("Product removed from the cart.");
            });
            
            app.MapPost("/orders", async (Order newOrder, MerchCopDbContext db) =>
            {
                var paymentType = await db.PaymentTypes.FindAsync(newOrder.PaymentTypeId);
                if (paymentType == null)
                {
                    return Results.NotFound($"PaymentType with ID {newOrder.PaymentTypeId} not found.");
                }

                var productType = await db.ProductTypes.FindAsync(newOrder.ProductTypeId);
                if (productType == null)
                {
                    return Results.NotFound($"ProductType with ID {newOrder.ProductTypeId} not found.");
                }

                await db.Orders.AddAsync(newOrder);
                await db.SaveChangesAsync();

                return Results.Created($"/orders/{newOrder.Id}", newOrder);
            });

            app.MapDelete("/orders/{orderId}", async (int orderId, MerchCopDbContext db) =>
            {
                var order = await db.Orders.FindAsync(orderId);

                if (order == null)
                {
                    return Results.NotFound($"Order with ID {orderId} not found.");
                }

                db.Orders.Remove(order);
                await db.SaveChangesAsync();

                return Results.Ok($"Order with ID {orderId} deleted successfully.");
            });


        }
    }
}

