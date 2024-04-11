using Tutorial4.Controllers;

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
    public static void MapVisitsEndpoints(this WebApplication app)
    {
        app.MapGet("/visits", () =>
        {
            return Results.Ok();
        });
    }
}