using Microsoft.EntityFrameworkCore;
using MC_MZ_PF_API.Data;
using MC_MZ_PF_API.Data.Models;
namespace MC_MZ_PF_API.Controllers;

public static class CulturaEndpoints
{
    public static void MapCulturaEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Cultura", async (McMzPfDataContext db) =>
        {
            return await db.Culturas.ToListAsync();
        })
        .WithName("GetAllCulturas")
        .Produces<List<Cultura>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Cultura/{id}", async (int Id, McMzPfDataContext db) =>
        {
            return await db.Culturas.FindAsync(Id)
                is Cultura model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetCulturaById")
        .Produces<Cultura>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Cultura/{id}", async (int Id, Cultura cultura, McMzPfDataContext db) =>
        {
            var foundModel = await db.Culturas.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(cultura);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateCultura")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Cultura/", async (Cultura cultura, McMzPfDataContext db) =>
        {
            db.Culturas.Add(cultura);
            await db.SaveChangesAsync();
            return Results.Created($"/Culturas/{cultura.Id}", cultura);
        })
        .WithName("CreateCultura")
        .Produces<Cultura>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Cultura/{id}", async (int Id, McMzPfDataContext db) =>
        {
            if (await db.Culturas.FindAsync(Id) is Cultura cultura)
            {
                db.Culturas.Remove(cultura);
                await db.SaveChangesAsync();
                return Results.Ok(cultura);
            }

            return Results.NotFound();
        })
        .WithName("DeleteCultura")
        .Produces<Cultura>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
