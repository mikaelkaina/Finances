using Financeiro.Application.DTOs.Income;
using Financeiro.Application.UseCases;
using System.Security.Claims;

namespace Financeiro.App.Endpoints;

public static class IncomeEndpoints
{
    public static void MapIncomeEndpoints(this WebApplication app)
    {
        app.MapPost("/api/incomes",
            async (
            AddIncomeInput input,
            AddIncomeUseCase useCase,
            ClaimsPrincipal user) =>
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                 return Results.Unauthorized();

            var command = input with { UserId = userId };

            await useCase.ExecuteAsync(command);

            return Results.Ok();

        })
           .RequireAuthorization();
    }
}
