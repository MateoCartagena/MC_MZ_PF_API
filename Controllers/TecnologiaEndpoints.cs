using Microsoft.EntityFrameworkCore;
using MC_MZ_PF_API.Data;
using MC_MZ_PF_API.Data.Models;
namespace MC_MZ_PF_API.Controllers;

public static class TecnologiaEndpoints
{
    public static void MapTecnologiaEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Tecnologia", async (McMzPfDataContext db) =>
        {
            return await db.Tecnologia.ToListAsync();
        })
        .WithName("GetAllTecnologias")
        .Produces<List<Tecnologia>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Tecnologia/{id}", async (int Id, McMzPfDataContext db) =>
        {
            return await db.Tecnologia.FindAsync(Id)
                is Tecnologia model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetTecnologiaById")
        .Produces<Tecnologia>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Tecnologia/{id}", async (int Id, Tecnologia tecnologia, McMzPfDataContext db) =>
        {
            var foundModel = await db.Tecnologia.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(tecnologia);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateTecnologia")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Tecnologia/", async (Tecnologia tecnologia, McMzPfDataContext db) =>
        {
            db.Tecnologia.Add(tecnologia);
            await db.SaveChangesAsync();
            return Results.Created($"/Tecnologias/{tecnologia.Id}", tecnologia);
        })
        .WithName("CreateTecnologia")
        .Produces<Tecnologia>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Tecnologia/{id}", async (int Id, McMzPfDataContext db) =>
        {
            if (await db.Tecnologia.FindAsync(Id) is Tecnologia tecnologia)
            {
                db.Tecnologia.Remove(tecnologia);
                await db.SaveChangesAsync();
                return Results.Ok(tecnologia);
            }

            return Results.NotFound();
        })
        .WithName("DeleteTecnologia")
        .Produces<Tecnologia>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
