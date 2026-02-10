using Financeiro.Application.DTOs.Income;
using Financeiro.Application.UseCases.UseIncome;
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

        app.MapGet("/api/incomes",
            async (
            ClaimsPrincipal user,
            GetIncomesUseCase useCase) =>
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                 return Results.Unauthorized();

            var result = await useCase.ExecuteAsync(userId);

            return Results.Ok(result);
        })
            .RequireAuthorization();

        app.MapDelete("/api/incomes/{id:guid}",
            async (
            Guid id,
            DeleteIncomeUseCase useCase,
            ClaimsPrincipal user) =>
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                 return Results.Unauthorized();

            await useCase.ExecuteAsync(new(id,userId));

            return Results.NoContent();
        })
            .RequireAuthorization();
    }
}
