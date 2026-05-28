using Financeiro.Application.DTOs.Expense;
using Financeiro.Application.UseCases.UseExpense.Commands;
using Financeiro.Application.UseCases.UseExpense.Queries;
using System.Security.Claims;

namespace Financeiro.App.Endpoints;

public static class ExpenseEndpoints
{
    public static void MapExpenseEndpoints(this WebApplication app)
    {
        app.MapPost("/api/expenses", 
            async (
            AddExpenseInput input,
            AddExpenseUseCase useCase,
            ClaimsPrincipal user) =>
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                 return Results.Unauthorized();

            var command = input with { UserId = userId };

            await useCase.ExecuteAsync(command);

            return Results.Ok();
        })
            .RequireAuthorization ();

        app.MapGet("/api/expenses",
            async (
            ClaimsPrincipal user,
            GetExpensesUseCase useCase) =>
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                 return Results.Unauthorized();

            var result = await useCase.ExecuteAsync(userId);

            return Results.Ok(result);
        })
            .RequireAuthorization();

        app.MapDelete("/api/expenses/{id:guid}",
            async (
            Guid id,
            DeleteExpenseUseCase useCase,
            ClaimsPrincipal user) =>
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                 return Results.Unauthorized();

            await useCase.ExecuteAsync(new(id,userId));

            return Results.NoContent();
        })
            .RequireAuthorization();

        app.MapPut("/api/expenses/{id:guid}",
            async (
            Guid Id,
            UpdateExpenseInput input,
            UpdateExpenseUseCase useCase,
            ClaimsPrincipal user) =>
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                 return Results.Unauthorized();

            await useCase.ExecuteAsync(input with { ExpenseId = Id, UserId = userId });

            return Results.NoContent();
        })
            .RequireAuthorization();
    }
}
