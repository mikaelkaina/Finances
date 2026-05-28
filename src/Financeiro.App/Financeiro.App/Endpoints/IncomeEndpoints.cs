using Financeiro.Application.UseCases.UseIncome.Commands.Add;
using Financeiro.Application.UseCases.UseIncome.Commands.Delete;
using Financeiro.Application.UseCases.UseIncome.Commands.Update;
using Financeiro.Application.UseCases.UseIncome.Queries.Get;
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

        app.MapPut("/api/incomes/{id:guid}",
            async (
            Guid id,
            UpdateIncomeInput input,
            UpdateIncomeUseCase useCase,
            ClaimsPrincipal user) =>
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                 return Results.Unauthorized();

            await useCase.ExecuteAsync(input with { IncomeId = id,UserId = userId });

            return Results.NoContent();
        })
            .RequireAuthorization();
    }
}
