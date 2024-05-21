namespace MerchCop.Requests
{
    public class PaymentTypes
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/payment-types", (MerchCopDbContext db) =>
            {
                return db.PaymentTypes.ToList();
            });

            app.MapGet("/payment-types/{paymentTypeId}", (int paymentTypeId, MerchCopDbContext db) =>
            {
                var paymentType = db.PaymentTypes.Find(paymentTypeId);

                if (paymentType == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(paymentType);
            });

        }

    }
}
