using Tutorial4.Models;

namespace Tutorial4.Endpoints;

public static class AnimalMappings
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        app.MapGet("/animals-minimalApi", () =>
        {
            return Results.Ok();
        });
    }
}