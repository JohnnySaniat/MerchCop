using MerchCop.Models;
using Microsoft.EntityFrameworkCore;

namespace MerchCop.Requests
{
    public class Orders
    {
        public static void Map(WebApplication app)
        {

            app.MapGet("/orders", (MerchCopDbContext db) =>
            {
                return db.Orders.Include(o => o.Products).ToList();
            });


        }
    }
}

