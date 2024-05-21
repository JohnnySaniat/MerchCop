namespace MerchCop.Requests
{
    public class ProductTypes
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/product-types", (MerchCopDbContext db) =>
            {
                return db.ProductTypes.ToList();
            });

            app.MapGet("/product-types/{productTypeId}", (int productTypeId, MerchCopDbContext db) =>
            {
                var productType = db.ProductTypes.Find(productTypeId);

                if (productType == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(productType);
            });

        }
    }
}
