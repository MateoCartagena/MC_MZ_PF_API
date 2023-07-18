using Microsoft.EntityFrameworkCore;
using MC_MZ_PF_API.Data;
using MC_MZ_PF_API.Data.Models;
namespace MC_MZ_PF_API.Controllers;

public static class DeporteEndpoints
{
    public static void MapDeporteEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Deporte", async (McMzPfDataContext db) =>
        {
            return await db.Deportes.ToListAsync();
        })
        .WithName("GetAllDeportes")
        .Produces<List<Deporte>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Deporte/{id}", async (int Id, McMzPfDataContext db) =>
        {
            return await db.Deportes.FindAsync(Id)
                is Deporte model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetDeporteById")
        .Produces<Deporte>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Deporte/{id}", async (int Id, Deporte deporte, McMzPfDataContext db) =>
        {
            var foundModel = await db.Deportes.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(deporte);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateDeporte")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Deporte/", async (Deporte deporte, McMzPfDataContext db) =>
        {
            db.Deportes.Add(deporte);
            await db.SaveChangesAsync();
            return Results.Created($"/Deportes/{deporte.Id}", deporte);
        })
        .WithName("CreateDeporte")
        .Produces<Deporte>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Deporte/{id}", async (int Id, McMzPfDataContext db) =>
        {
            if (await db.Deportes.FindAsync(Id) is Deporte deporte)
            {
                db.Deportes.Remove(deporte);
                await db.SaveChangesAsync();
                return Results.Ok(deporte);
            }

            return Results.NotFound();
        })
        .WithName("DeleteDeporte")
        .Produces<Deporte>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
