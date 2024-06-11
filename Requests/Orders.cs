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
                    .Include(o => o.ProductType)
                    .ToList();
            });

            app.MapGet("/orders/{orderId}", (int orderId, MerchCopDbContext db) =>
            {
                var order = db.Orders
                    .Include(o => o.Products)
                    .Include(o => o.ProductType)
                    .SingleOrDefault(o => o.Id == orderId);

                if (order == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(order);
            });

            app.MapPut("/orders/{orderId}/complete", async (int orderId, string paymentType, MerchCopDbContext db) =>
            {
                var order = await db.Orders.FindAsync(orderId);

                if (order == null)
                {
                    return Results.NotFound();
                }

                order.IsComplete = true;
                order.PaymentType = paymentType;

                db.Orders.Update(order);
                await db.SaveChangesAsync();

                return Results.Ok(order);
            });

            app.MapPost("/orders/{orderId}/products/{productId}", async (int orderId, int productId, MerchCopDbContext db) =>
            {
                var order = await db.Orders.Include(o => o.Products).SingleOrDefaultAsync(o => o.Id == orderId);

                if (order == null)
                {
                    return Results.NotFound($"Order with ID {orderId} not found.");
                }

                var product = await db.Products.FindAsync(productId);

                if (product == null)
                {
                    return Results.NotFound($"Product with ID {productId} not found.");
                }

                order.Products.Add(product);

                order.Total += product.Price;
                order.CalculateTotalWithTax();

                db.Orders.Update(order);
                await db.SaveChangesAsync();

                return Results.Created($"/orders/{order.Id}", order);
            });

            app.MapDelete("/orders/{orderId}/products/{productId}", async (MerchCopDbContext db, int orderId, int productId) =>
            {
                var order = await db.Orders.Include(o => o.Products).SingleOrDefaultAsync(o => o.Id == orderId);

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

                // Recalculate total and tax
                order.Total -= productToRemove.Price;
                order.CalculateTotalWithTax();

                db.SaveChanges();

                return Results.Ok("Product removed from the cart.");
            });

            app.MapPost("/orders", async (Order newOrder, MerchCopDbContext db) =>
            {
                var productType = await db.ProductTypes.FindAsync(newOrder.ProductTypeId);
                if (productType == null)
                {
                    return Results.NotFound($"ProductType with ID {newOrder.ProductTypeId} not found.");
                }

                newOrder.CalculateTotalWithTax();

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

            app.MapGet("/orders/{id}/products", (MerchCopDbContext db, int id) =>
            {
                var Order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == id);
                return Order;
            });

            app.MapGet("/orders/open", async (MerchCopDbContext db) =>
            {
                var openOrders = await db.Orders
                    .Where(order => !order.IsComplete)
                    .ToListAsync();

                return Results.Ok(openOrders);
            });

            app.MapPut("/orders/{orderId}", async (int orderId, Order updatedOrder, MerchCopDbContext db) =>
            {
                var order = await db.Orders.FindAsync(orderId);

                if (order == null)
                {
                    return Results.NotFound();
                }

                order.IsComplete = updatedOrder.IsComplete;
                order.PaymentType = updatedOrder.PaymentType;
                order.TotalWithTax = updatedOrder.TotalWithTax;

                db.Orders.Update(order);
                await db.SaveChangesAsync();

                return Results.Ok(order);
            });

            app.MapGet("/orders/user/{userId}", async (int userId, MerchCopDbContext db) =>
            {
                return await db.Orders
                    .Include(o => o.Products)
                    .Include(o => o.ProductType)
                    .Where(o => o.UserId == userId)
                    .ToListAsync();
            });

            app.MapPost("/orders/user/{userId}", async (Order newOrder, int userId, MerchCopDbContext db) =>
            {
                var productType = await db.ProductTypes.FindAsync(newOrder.ProductTypeId);
                if (productType == null)
                {
                    return Results.NotFound($"ProductType with ID {newOrder.ProductTypeId} not found.");
                }

                newOrder.UserId = userId; // Assign the userId to the order

                newOrder.CalculateTotalWithTax();

                await db.Orders.AddAsync(newOrder);
                await db.SaveChangesAsync();

                return Results.Created($"/orders/{newOrder.Id}", newOrder);
            });
        }
    }
}
