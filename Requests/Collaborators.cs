using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MerchCop.Models;
using System.Linq;

namespace MerchCop.Requests
{
    public class Collaborators
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/collaborators", (MerchCopDbContext db) =>
            {
                return db.Collaborators
                    .Include(c => c.Products)
                    .ToList();
            });

            app.MapGet("/collaborators/{collaboratorId}", (int collaboratorId, MerchCopDbContext db) =>
            {
                var collaborator = db.Collaborators
                    .Include(c => c.Products)
                    .SingleOrDefault(c => c.Id == collaboratorId);

                if (collaborator == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(collaborator);
            });

            app.MapGet("/collaborator/{id}", (MerchCopDbContext db, int id) =>
            {
                var Collaborator = db.Collaborators.Include(o => o.Products).FirstOrDefault(o => o.Id == id);
                return Collaborator;
            });
        }
    }
}
