using Microsoft.EntityFrameworkCore;
using MC_MZ_PF_API.Data;
using MC_MZ_PF_API.Data.Models;
namespace MC_MZ_PF_API.Controllers;

public static class ArteEndpoints
{
    public static void MapArteEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Arte", async (McMzPfDataContext db) =>
        {
            return await db.Artes.ToListAsync();
        })
        .WithName("GetAllArtes")
        .Produces<List<Arte>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Arte/{id}", async (int Id, McMzPfDataContext db) =>
        {
            return await db.Artes.FindAsync(Id)
                is Arte model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetArteById")
        .Produces<Arte>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Arte/{id}", async (int Id, Arte arte, McMzPfDataContext db) =>
        {
            var foundModel = await db.Artes.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(arte);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateArte")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Arte/", async (Arte arte, McMzPfDataContext db) =>
        {
            db.Artes.Add(arte);
            await db.SaveChangesAsync();
            return Results.Created($"/Artes/{arte.Id}", arte);
        })
        .WithName("CreateArte")
        .Produces<Arte>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Arte/{id}", async (int Id, McMzPfDataContext db) =>
        {
            if (await db.Artes.FindAsync(Id) is Arte arte)
            {
                db.Artes.Remove(arte);
                await db.SaveChangesAsync();
                return Results.Ok(arte);
            }

            return Results.NotFound();
        })
        .WithName("DeleteArte")
        .Produces<Arte>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
