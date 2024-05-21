using MerchCop.DTOs;
using MerchCop.Models;
using Microsoft.EntityFrameworkCore;

namespace MerchCop.Requests
{
    public class Users
    {
        public static void Map(WebApplication app)
        {

            app.MapPost("users/checkuser", (MerchCopDbContext db, UserAuthDTO userAuthDTO) =>
            {
                var userUid = db.Users.SingleOrDefault(u => u.Uid == userAuthDTO.Uid);

                if (userUid == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(userUid);
                }
            });

            app.MapPost("users/register", (MerchCopDbContext db, User user) =>
            {
                db.Users.Add(user);
                db.SaveChanges();
                return Results.Created($"/user/{user.Id}", user);
            });

            app.MapGet("/users/{id}", (MerchCopDbContext db, int id) =>
            {
                return db.Users
                    .Include(u => u.Orders)
                        .ThenInclude(o => o.Products)
                    .FirstOrDefault(u => u.Id == id);
            });

            app.MapPatch("users/{id}", (MerchCopDbContext db, int id, User user) =>
            {
                User userToUpdate = db.Users.SingleOrDefault(u => u.Id == id);
                if (userToUpdate == null)
                {
                    return Results.NotFound();
                }
                userToUpdate.Uid = user.Uid;
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.UserName = user.UserName;
                userToUpdate.Address = user.Address;
                userToUpdate.Email = user.Email;
                userToUpdate.Image = user.Image;
                userToUpdate.IsSeller = user.IsSeller;
                userToUpdate.IsAdmin = user.IsAdmin;
                db.SaveChanges();
                return Results.Ok(userToUpdate);
            });

            app.MapPost("/users/new", async (MerchCopDbContext db, User user) =>
            {
                var existingUser = await db.Users.SingleOrDefaultAsync(u => u.Uid == user.Uid);
                if (existingUser != null)
                {
                    return Results.Conflict("A user with this UID already exists.");
                }

                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();

                return Results.Created($"/users/{user.Id}", user);
            });

            app.MapPatch("/users/{uid}/switch-to-seller", async (string uid, MerchCopDbContext db) =>
            {
                var user = await db.Users.SingleOrDefaultAsync(u => u.Uid == uid);

                if (user == null)
                {
                    return Results.NotFound();
                }

                user.IsSeller = true;

                db.Users.Update(user);
                await db.SaveChangesAsync();

                return Results.Ok(user);
            });

        }
    }
}
